using System;
using System.Collections.Generic;
using System.Linq;
using Ponics.Analysis.Levels;
using Ponics.Analysis.Levels.Handlers;
using Ponics.Analysis.PonicsSystem.Pipelines.AnalyseLevels;
using Ponics.Aquaponics;
using Ponics.Kernel.Pipelines;
using Ponics.Kernel.Queries;
using Ponics.Organisms;
using Ponics.Strategies;

namespace Ponics.Analysis.PonicsSystem
{
    public class AnalysePonicsSystemHandler : IQueryHandler<AnalysePonicsSystem, PonicsSystemAnalysis>
    {
        private readonly IQueryStrategyHandler<GetPonicSystemOrganisms, List<Organism>> _getPonicSystemOrganismsHandler;
        private readonly IDataQueryHandler<GetSystem, AquaponicSystem> _getSystemDataQueryHandler;
        private readonly IEnumerable<IAnalyseLevelsQueryHandler> _analyseLevelsQueryHandlers;
        private readonly Pipeline<Node<PonicsSystemAnalysis, AnalyseLevelsPipelineContext>, PonicsSystemAnalysis, AnalyseLevelsPipelineContext> _analyseLevelsPipeline;

        public AnalysePonicsSystemHandler(
            IQueryStrategyHandler<GetPonicSystemOrganisms, List<Organism>> getPonicSystemOrganismsHandler,
            IDataQueryHandler<GetSystem, AquaponicSystem> getSystemDataQueryHandler,
            IEnumerable<IAnalyseLevelsQueryHandler> analyseLevelsQueryHandlers,
            Pipeline<Node<PonicsSystemAnalysis, AnalyseLevelsPipelineContext>, PonicsSystemAnalysis, AnalyseLevelsPipelineContext> analyseLevelsPipeline
            )
        {
            _getPonicSystemOrganismsHandler = getPonicSystemOrganismsHandler;
            _getSystemDataQueryHandler = getSystemDataQueryHandler;
            _analyseLevelsQueryHandlers = analyseLevelsQueryHandlers;
            _analyseLevelsPipeline = analyseLevelsPipeline;
        }

        public PonicsSystemAnalysis Handle(AnalysePonicsSystem query)
        {
            var result = new PonicsSystemAnalysis();

            var system = _getSystemDataQueryHandler.Handle(new GetSystem
            {
                SystemId = query.SystemId

            });

            var systemOrganisms = _getPonicSystemOrganismsHandler.Handle(new GetPonicSystemOrganisms
                {
                    SystemId = query.SystemId
                });

            var levelReadings = system.LevelReadings
                .OrderByDescending(t => t.DateTime.ToDateTimeUtc())
                .GroupBy(t => t.Type)
                .Select(g => g.First());

            var context = new AnalyseLevelsPipelineContext();
            foreach (var levelReading in levelReadings)
            {
                var handler = _analyseLevelsQueryHandlers.SingleOrDefault(h => h.AnalyserFor == levelReading.Type);

                if (handler == null)
                {
                    result.Items.Add(new PonicsSystemAnalysisItem
                    {
                        PonicsSystemAnalysisType = PonicsSystemAnalysisType.Error,
                        Title = $"Could not handel {levelReading.Type}",
                        Message = "Please contact support"
                    });
                    continue;
                }

                foreach (var organism in systemOrganisms)
                {
                    var analyseToleranceQuery = Activator.CreateInstance(handler.QueryType) as AnalyseToleranceQuery;
                    analyseToleranceQuery.Value =  levelReading.Value;
                    analyseToleranceQuery.OrganismId = organism.Id;

                    LevelAnalysis analyse;
                    try
                    {
                        analyse = handler.Handle(analyseToleranceQuery);
                    }
                    catch (Exception e)
                    {
                        result.Items.Add(new PonicsSystemAnalysisItem
                        {
                            Title = $"Exception handling analysis for {organism.Name}",
                            PonicsSystemAnalysisType = PonicsSystemAnalysisType.Error,
                            Message = e.Message
                        });

                        continue;
                    }
                    context.Add(new AnalyseLevelsPipelineContextItem(analyse, levelReading, organism));
                }
                
            }
            _analyseLevelsPipeline.Execute(result, context);

            result.Items = result.Items
                .OrderBy(i => i.PonicsSystemAnalysisType)
                .ToList();

            return result;
        }
    }
}

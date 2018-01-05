using System;
using System.Collections.Generic;
using System.Linq;
using Ponics.Analysis.Levels;
using Ponics.Analysis.Levels.Handlers;
using Ponics.Aquaponics;
using Ponics.Kernel.Queries;
using Ponics.Organisms;
using Ponics.Strategies;

namespace Ponics.Analysis.PonicsSystem
{
    public class AnalysePonicsSystemHandler : IQueryHandler<AnalysePonicsSystem, List<PonicsSystemAnalysis>>
    {
        private readonly IQueryStrategyHandler<GetPonicSystemOrganisms, List<Organism>> _getPonicSystemOrganismsHandler;
        private readonly IDataQueryHandler<GetSystem, AquaponicSystem> _getSystemDataQueryHandler;
        private readonly IEnumerable<IAnalyseLevelsQueryHandler> _analyseLevelsQueryHandlers;

        public AnalysePonicsSystemHandler(
            IQueryStrategyHandler<GetPonicSystemOrganisms, List<Organism>> getPonicSystemOrganismsHandler,
            IDataQueryHandler<GetSystem, AquaponicSystem> getSystemDataQueryHandler,
            IEnumerable<IAnalyseLevelsQueryHandler> analyseLevelsQueryHandlers
            )
        {
            _getPonicSystemOrganismsHandler = getPonicSystemOrganismsHandler;
            _getSystemDataQueryHandler = getSystemDataQueryHandler;
            _analyseLevelsQueryHandlers = analyseLevelsQueryHandlers;
        }

        public List<PonicsSystemAnalysis> Handle(AnalysePonicsSystem query)
        {
            var result = new List<PonicsSystemAnalysis>();

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


            foreach (var levelReading in levelReadings)
            {
                var handler = _analyseLevelsQueryHandlers.SingleOrDefault(h => h.AnalyserFor == levelReading.Type);

                foreach (var organism in systemOrganisms)
                {
                    var analyseToleranceQuery = Activator.CreateInstance(handler.QueryType) as AnalyseToleranceQuery;
                    analyseToleranceQuery.Value =  levelReading.Value;
                    analyseToleranceQuery.OrganismId = organism.Id;

                    LevelAnalysis analyse = null;
                    try
                    {
                        analyse = handler.Handle(analyseToleranceQuery);
                    }
                    catch (Exception e)
                    {
                        result.Add(new PonicsSystemAnalysis
                        {
                            PonicsSystemAnalysisType = PonicsSystemAnalysisType.Error,
                            Category = nameof(Organism),
                            Identifier = organism.Id.ToString(),
                            Message = e.Message
                        });
                    }

                    if (analyse == null)
                    {
                        continue;
                    }

                    if (!analyse.IdealForOrganism && analyse.SuitableForOrganism)
                    {
                        result.Add(new PonicsSystemAnalysis
                        {
                            PonicsSystemAnalysisType = PonicsSystemAnalysisType.Warning,
                            Category = nameof(Organism),
                            Identifier = organism.Id.ToString(),
                            Message = $"A {levelReading.Type} level of {levelReading.Value} is not ideal for {organism.Name}",
                        });
                    }

                    if (!analyse.SuitableForOrganism)
                    {
                        result.Add(new PonicsSystemAnalysis
                        {
                            PonicsSystemAnalysisType = PonicsSystemAnalysisType.Error,
                            Category = nameof(Organism),
                            Identifier = organism.Id.ToString(),
                            Message = $"A {levelReading.Type} level of {levelReading.Value} is not Suitable for {organism.Name}",
                        });
                    }
                }
                
            }
            

            return result;
        }
    }
}

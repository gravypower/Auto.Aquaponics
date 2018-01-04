using System.Collections.Generic;
using System.Linq;
using Ponics.Analysis.Levels;
using Ponics.Analysis.Levels.Handlers;
using Ponics.Aquaponics;
using Ponics.Kernel.Queries;
using Ponics.Organisms;
using Ponics.Strategies;

namespace Ponics.Analysis.PonicsSystemLevels
{
    public class AnalysePonicsSystemLevelsHandler : IQueryHandler<AnalysePonicsSystemLevels, PonicsSystemLevelsAnalysis>
    {
        private readonly IQueryStrategyHandler<GetPonicSystemOrganisms, List<Organism>> _getPonicSystemOrganismsHandler;
        private readonly IDataQueryHandler<GetSystem, AquaponicSystem> _getSystemDataQueryHandler;
        private readonly IEnumerable<IAnalyseLevelsQueryHandler> _analyseLevelsQueryHandlers;

        public AnalysePonicsSystemLevelsHandler(
            IQueryStrategyHandler<GetPonicSystemOrganisms, List<Organism>> getPonicSystemOrganismsHandler,
            IDataQueryHandler<GetSystem, AquaponicSystem> getSystemDataQueryHandler,
            IEnumerable<IAnalyseLevelsQueryHandler> analyseLevelsQueryHandlers
            )
        {
            _getPonicSystemOrganismsHandler = getPonicSystemOrganismsHandler;
            _getSystemDataQueryHandler = getSystemDataQueryHandler;
            _analyseLevelsQueryHandlers = analyseLevelsQueryHandlers;
        }

        public PonicsSystemLevelsAnalysis Handle(AnalysePonicsSystemLevels query)
        {
            var result = new PonicsSystemLevelsAnalysis();

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

                foreach (var systemOrganism in systemOrganisms)
                {
                    var analyse = handler.Handle(new AnalyseToleranceQuery
                    {
                        OrganismId = systemOrganism.Id,
                        Value = levelReading.Value
                    });
                }
                
            }
            

            return result;
        }
    }
}

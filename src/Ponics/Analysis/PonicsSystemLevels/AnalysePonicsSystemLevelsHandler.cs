using System.Collections.Generic;
using System.Linq;
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

        public AnalysePonicsSystemLevelsHandler(
            IQueryStrategyHandler<GetPonicSystemOrganisms, List<Organism>> getPonicSystemOrganismsHandler,
            IDataQueryHandler<GetSystem, AquaponicSystem> getSystemDataQueryHandler
            )
        {
            _getPonicSystemOrganismsHandler = getPonicSystemOrganismsHandler;
            _getSystemDataQueryHandler = getSystemDataQueryHandler;
        }

        public PonicsSystemLevelsAnalysis Handle(AnalysePonicsSystemLevels query)
        {
            var result = new PonicsSystemLevelsAnalysis();

            var system = _getSystemDataQueryHandler.Handle(new GetSystem
            {
                SystemId = query.SystemId

            });

            var toleranceTypes = system.LevelReadings
                .OrderByDescending(t => t.DateTime.ToDateTimeUtc())
                .GroupBy(t => t.Type)
                .Select(g => g.First());


            foreach (var toleranceType in toleranceTypes)
            {
                
            }
            

            return result;
        }
    }
}

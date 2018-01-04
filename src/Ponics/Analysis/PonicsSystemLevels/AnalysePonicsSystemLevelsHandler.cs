using System.Collections.Generic;
using Ponics.Kernel.Queries;
using Ponics.Organisms;
using Ponics.Strategies;

namespace Ponics.Analysis.PonicsSystemLevels
{
    public class AnalysePonicsSystemLevelsHandler : IQueryHandler<AnalysePonicsSystemLevels, PonicsSystemLevelsAnalysis>
    {
        private readonly IQueryStrategyHandler<GetPonicSystemOrganisms, List<Organism>> _getPonicSystemOrganismsHandler;

        public AnalysePonicsSystemLevelsHandler(IQueryStrategyHandler<GetPonicSystemOrganisms, List<Organism>> getPonicSystemOrganismsHandler)
        {
            _getPonicSystemOrganismsHandler = getPonicSystemOrganismsHandler;
        }

        public PonicsSystemLevelsAnalysis Handle(AnalysePonicsSystemLevels query)
        {
            var result = new PonicsSystemLevelsAnalysis();
           



            return result;
        }
    }
}

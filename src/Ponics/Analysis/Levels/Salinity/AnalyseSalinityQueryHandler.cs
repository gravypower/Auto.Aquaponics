using System.Collections.Generic;
using Ponics.Analysis.Levels.Handlers;
using Ponics.Kernel.Data;
using Ponics.Organisms;

namespace Ponics.Analysis.Levels.Salinity
{
    public class AnalyseSalinityQueryHandler: AnalyseLevelsQueryHandler<AnalyseToleranceSalinity, SalinityToleranceAnalysis, SalinityTolerance>
    {
        private readonly IAnalyseSalinityMagicStrings _magicStrings;

        public AnalyseSalinityQueryHandler(
            IAnalyseSalinityMagicStrings magicStrings,
            IDataQueryHandler<GetAllOrganisms, List<Organism>> getAllOrganismsDataQueryHandler
            ) : base(magicStrings, getAllOrganismsDataQueryHandler)
        {
            _magicStrings = magicStrings;
        }

        protected override SalinityToleranceAnalysis Analyse(AnalyseToleranceSalinity query, SalinityToleranceAnalysis toleranceAnalysis, Organism organism)
        {
            return toleranceAnalysis;
        }

        protected override void OrganismToleranceNotDefined()
        {
            throw new System.NotImplementedException();
        }
    }
}

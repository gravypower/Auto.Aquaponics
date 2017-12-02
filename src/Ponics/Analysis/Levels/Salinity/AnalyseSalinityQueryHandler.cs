using System.Collections.Generic;
using Ponics.Kernel.Data;
using Ponics.Organisms;

namespace Ponics.Analysis.Levels.Salinity
{
    public class AnalyseSalinityQueryHandler: AnalyseLevelsQueryHandler<AnalyseSalinity, SalinityAnalysis, SalinityTolerance>
    {
        private readonly IAnalyseSalinityMagicStrings _magicStrings;

        public AnalyseSalinityQueryHandler(
            IAnalyseSalinityMagicStrings magicStrings,
            IDataQueryHandler<GetAllOrganisms, IList<Organism>> getAllOrganismsDataQueryHandler
            ) : base(magicStrings, getAllOrganismsDataQueryHandler)
        {
            _magicStrings = magicStrings;
        }

        protected override SalinityAnalysis Analyse(AnalyseSalinity query, SalinityAnalysis analysis, Organism organism)
        {
            return analysis;
        }

        protected override void OrganismToleranceNotDefined()
        {
            throw new System.NotImplementedException();
        }
    }
}

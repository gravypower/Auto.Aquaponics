using Auto.Aquaponics.Organisms;
using System.Collections.Generic;
using Auto.Aquaponics.Kernel.Data;

namespace Auto.Aquaponics.Analysis.Levels.Salinity
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

using Auto.Aquaponics.Organisms;
using System.Collections.Generic;
using Auto.Aquaponics.Kernel.Data;
using Auto.Aquaponics.Tolerances;

namespace Auto.Aquaponics.Analysis.Levels.Ammonia
{
    public class AnalyseAmmoniaQueryHandler: AnalyseLevelsQueryHandler<AnalyseAmmonia, AmmoniaAnalysis, AmmoniaTolerance>
    {
        private readonly IAnalyseAmmoniaMagicStrings _magicStrings;

        public AnalyseAmmoniaQueryHandler(
            IAnalyseAmmoniaMagicStrings magicStrings,
            IDataQueryHandler<GetAllOrganisms, IList<Organism>> getAllOrganismsDataQueryHandler
        ) : base(magicStrings, getAllOrganismsDataQueryHandler)
        {
            _magicStrings = magicStrings;
        }

        protected override AmmoniaAnalysis Analyse(AnalyseAmmonia query, AmmoniaAnalysis analysis, Organism organism)
        {
            return analysis;
        }

        protected override void OrganismToleranceNotDefined()
        {
            throw new System.NotImplementedException();
        }
    }
}

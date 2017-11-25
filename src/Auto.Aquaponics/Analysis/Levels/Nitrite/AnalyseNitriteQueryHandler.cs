using Auto.Aquaponics.Organisms;
using System.Collections.Generic;
using Auto.Aquaponics.Kernel.Data;
using Auto.Aquaponics.Tolerances;

namespace Auto.Aquaponics.Analysis.Levels.Nitrite
{
    public class AnalyseNitriteQueryHandler : AnalyseLevelsQueryHandler<AnalyseNitrite, NitriteAnalysis, NitriteTolerance>
    {
        private readonly IAnalyseNitriteMagicStrings _magicStrings;

        public AnalyseNitriteQueryHandler(
            IAnalyseNitriteMagicStrings magicStrings,
            IDataQueryHandler<GetAllOrganisms, IList<Organism>> getAllOrganismsDataQueryHandler
        ) : base(magicStrings, getAllOrganismsDataQueryHandler)
        {
            _magicStrings = magicStrings;
        }

        protected override NitriteAnalysis Analyse(AnalyseNitrite query, NitriteAnalysis analysis, Organism organism)
        {
            return analysis;
        }

        protected override void OrganismToleranceNotDefined()
        {
            throw new System.NotImplementedException();
        }
    }
}

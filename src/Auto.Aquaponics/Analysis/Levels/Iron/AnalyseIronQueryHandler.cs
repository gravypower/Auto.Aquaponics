using System.Collections.Generic;
using Auto.Aquaponics.Kernel.Data;
using Auto.Aquaponics.Organisms;
using Auto.Aquaponics.Tolerances;

namespace Auto.Aquaponics.Analysis.Levels.Iron
{
    public class AnalyseIronQueryHandler: AnalyseLevelsQueryHandler<AnalyseIron, IronAnalysis, IronTolerance>
    {
        private readonly IAnalyseIronMagicStrings _magicStrings;

        public AnalyseIronQueryHandler(
            IAnalyseIronMagicStrings magicStrings,
            IDataQueryHandler<GetAllOrganisms, IList<Organism>> getAllOrganismsDataQueryHandler
        ) : base(magicStrings, getAllOrganismsDataQueryHandler)
        {
            _magicStrings = magicStrings;
        }

        protected override IronAnalysis Analyse(AnalyseIron query, IronAnalysis analysis, Organism organism)
        {
            return analysis;
        }

        protected override void OrganismToleranceNotDefined()
        {
            throw new System.NotImplementedException();
        }
    }
}

using Auto.Aquaponics.Organisms;
using System.Collections.Generic;
using Auto.Aquaponics.Kernel.DataQuery;

namespace Auto.Aquaponics.Analysis.Level.Salinity
{
    public class SalinityLevelAnalysisQueryHandler: LevelAnalysisQueryHandler<SalinityLevelAnalysisQuery, SalinityLevelAnalysis>
    {
        private readonly ISalinityLevelAnalysisMagicStrings _magicStrings;

        public SalinityLevelAnalysisQueryHandler(
            ISalinityLevelAnalysisMagicStrings magicStrings,
            IDataQueryHandler<GetAllOrganisms, IList<Organism>> getAllOrganismsDataQueryHandler
            ) : base(magicStrings, getAllOrganismsDataQueryHandler)
        {
            _magicStrings = magicStrings;
        }

        protected override SalinityLevelAnalysis Analyse(SalinityLevelAnalysisQuery query, SalinityLevelAnalysis analysis, Organism organism)
        {
            return analysis;
        }

    }
}

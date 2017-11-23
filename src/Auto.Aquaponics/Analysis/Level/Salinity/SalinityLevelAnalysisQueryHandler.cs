using Auto.Aquaponics.Organisms;
using System.Collections.Generic;

namespace Auto.Aquaponics.Analysis.Level.Salinity
{
    public class SalinityLevelAnalysisQueryHandler: LevelAnalysisQueryHandler<SalinityLevelAnalysisQuery, SalinityLevelAnalysis>
    {
        private readonly ISalinityLevelAnalysisMagicStrings _magicStrings;

        public SalinityLevelAnalysisQueryHandler(
            ISalinityLevelAnalysisMagicStrings magicStrings,
            IEnumerable<Organism> organisms
            ) : base(magicStrings, organisms)
        {
            _magicStrings = magicStrings;
        }

        protected override SalinityLevelAnalysis Analyse(SalinityLevelAnalysisQuery query, SalinityLevelAnalysis analysis)
        {
            return analysis;
        }

    }
}

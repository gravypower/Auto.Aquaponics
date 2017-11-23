using Auto.Aquaponics.Organisms;
using System.Collections.Generic;

namespace Auto.Aquaponics.Analysis.Level.Nitrate
{
    public class NitrateLevelAnalysisQueryHandler: LevelAnalysisQueryHandler<NitrateLevelAnalysisQuery, NitrateLevelAnalysis>
    {
        private readonly INitrateLevelAnalysisMagicStrings _magicStrings;

        public NitrateLevelAnalysisQueryHandler(
            INitrateLevelAnalysisMagicStrings magicStrings,
            IEnumerable<Organism> organisms
            ) : base(magicStrings, organisms)
        {
            _magicStrings = magicStrings;
        }

        protected override NitrateLevelAnalysis Analyse(NitrateLevelAnalysisQuery query, NitrateLevelAnalysis analysis)
        {
            return analysis;
        }

    }
}

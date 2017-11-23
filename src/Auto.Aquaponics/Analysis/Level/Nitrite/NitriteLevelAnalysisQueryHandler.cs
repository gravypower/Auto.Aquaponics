using Auto.Aquaponics.Organisms;
using System.Collections.Generic;

namespace Auto.Aquaponics.Analysis.Level.Nitrite
{
    public class NitriteLevelAnalysisQueryHandler : LevelAnalysisQueryHandler<NitriteLevelAnalysisQuery, NitriteLevelAnalysis>
    {
        private readonly INitriteLevelAnalysisMagicStrings _magicStrings;

        public NitriteLevelAnalysisQueryHandler(
            INitriteLevelAnalysisMagicStrings nitriteLevelAnalysisMagicStrings,
            IEnumerable<Organism> organisms
            ) : base(nitriteLevelAnalysisMagicStrings, organisms)
        {
            _magicStrings = nitriteLevelAnalysisMagicStrings;
        }

        protected override NitriteLevelAnalysis Analyse(NitriteLevelAnalysisQuery query, NitriteLevelAnalysis analysis)
        {
            return analysis;
        }
    }
}

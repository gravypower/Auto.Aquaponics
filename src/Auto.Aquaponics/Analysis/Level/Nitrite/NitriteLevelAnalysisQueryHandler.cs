namespace Auto.Aquaponics.Analysis.Level.Nitrite
{
    public class NitriteLevelAnalysisQueryHandler : LevelAnalysisQueryHandler<NitriteLevelAnalysisQuery, NitriteLevelAnalysis>
    {
        private readonly INitriteLevelAnalysisMagicStrings _magicStrings;

        public NitriteLevelAnalysisQueryHandler(INitriteLevelAnalysisMagicStrings nitriteLevelAnalysisMagicStrings) : base(nitriteLevelAnalysisMagicStrings)
        {
            _magicStrings = nitriteLevelAnalysisMagicStrings;
        }

        protected override NitriteLevelAnalysis Analyse(NitriteLevelAnalysisQuery query, NitriteLevelAnalysis analysis)
        {
            return analysis;
        }
    }
}

namespace Auto.Aquaponics.Analysis.Level.Salinity
{
    public class SalinityLevelAnalysisQueryHandler: LevelAnalysisQueryHandler<SalinityLevelAnalysisQuery, SalinityLevelAnalysis>
    {
        private readonly ISalinityLevelAnalysisMagicStrings _magicStrings;

        public SalinityLevelAnalysisQueryHandler(ISalinityLevelAnalysisMagicStrings magicStrings) : base(magicStrings)
        {
            _magicStrings = magicStrings;
        }

        protected override SalinityLevelAnalysis Analyse(SalinityLevelAnalysisQuery query, SalinityLevelAnalysis analysis)
        {
            return analysis;
        }

    }
}

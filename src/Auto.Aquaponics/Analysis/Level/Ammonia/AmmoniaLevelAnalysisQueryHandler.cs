namespace Auto.Aquaponics.Analysis.Level.Ammonia
{
    public class AmmoniaLevelAnalysisQueryHandler: LevelAnalysisQueryHandler<AmmoniaLevelAnalysisQuery, AmmoniaLevelAnalysis>
    {
        private readonly IAmmoniaLevelAnalysisMagicStrings _magicStrings;

        public AmmoniaLevelAnalysisQueryHandler(IAmmoniaLevelAnalysisMagicStrings magicStrings) : base(magicStrings)
        {
            _magicStrings = magicStrings;
        }

        protected override AmmoniaLevelAnalysis Analyse(AmmoniaLevelAnalysisQuery query, AmmoniaLevelAnalysis analysis)
        {
            return analysis;
        }
    }
}

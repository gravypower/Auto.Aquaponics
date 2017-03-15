namespace Auto.Aquaponics.Analysis.Level.Nitrate
{
    public class NitrateLevelAnalysisQueryHandler: LevelAnalysisQueryHandler<NitrateLevelAnalysisQuery, NitrateLevelAnalysis>
    {
        private readonly INitrateLevelAnalysisMagicStrings _magicStrings;

        public NitrateLevelAnalysisQueryHandler(INitrateLevelAnalysisMagicStrings magicStrings) : base(magicStrings)
        {
            _magicStrings = magicStrings;
        }

        protected override NitrateLevelAnalysis Analyse(NitrateLevelAnalysisQuery query, NitrateLevelAnalysis analysis)
        {
            return analysis;
        }

    }
}

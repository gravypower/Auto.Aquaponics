namespace Auto.Aquaponics.Query.LevelAnalysis.Nitrate
{
    public class NitrateLevelQueryHandler: LevelQueryHandler<NitrateLevelAnalysis, NitrateLevelAnalysisResult>
    {
        private readonly INitrateLevelQueryHandlerMagicStrings _nitrateLevelQueryHandlerMagicStrings;

        public NitrateLevelQueryHandler(INitrateLevelQueryHandlerMagicStrings nitrateLevelQueryHandlerMagicStrings) : base(nitrateLevelQueryHandlerMagicStrings)
        {
            _nitrateLevelQueryHandlerMagicStrings = nitrateLevelQueryHandlerMagicStrings;
        }

        protected override NitrateLevelAnalysisResult Analyse(NitrateLevelAnalysis query, NitrateLevelAnalysisResult analysisResult)
        {
            return analysisResult;
        }

    }
}

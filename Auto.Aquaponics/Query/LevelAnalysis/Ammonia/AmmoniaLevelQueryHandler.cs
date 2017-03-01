namespace Auto.Aquaponics.Query.LevelAnalysis.Ammonia
{
    public class AmmoniaLevelQueryHandler: LevelQueryHandler<AmmoniaLevelAnalysis, AmmoniaLevelAnalysisResult>
    {
        private readonly IAmmoniaLevelQueryHandlerMagicStrings _ammoniaLevelQueryHandlerMagicStrings;

        public AmmoniaLevelQueryHandler(IAmmoniaLevelQueryHandlerMagicStrings ammoniaLevelQueryHandlerMagicStrings) : base(ammoniaLevelQueryHandlerMagicStrings)
        {
            _ammoniaLevelQueryHandlerMagicStrings = ammoniaLevelQueryHandlerMagicStrings;
        }

        protected override AmmoniaLevelAnalysisResult Analyse(AmmoniaLevelAnalysis query, AmmoniaLevelAnalysisResult analysisResult)
        {
            return analysisResult;
        }

    }
}

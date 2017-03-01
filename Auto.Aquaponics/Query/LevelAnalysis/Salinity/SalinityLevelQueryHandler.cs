namespace Auto.Aquaponics.Query.LevelAnalysis.Salinity
{
    public class SalinityLevelQueryHandler: LevelQueryHandler<SalinityLevelAnalysis, SalinityLevelAnalysisResult>
    {
        private readonly ISalinityLevelQueryHandlerMagicStrings _salinityLevelQueryHandlerMagicStrings;

        public SalinityLevelQueryHandler(ISalinityLevelQueryHandlerMagicStrings salinityLevelQueryHandlerMagicStrings) : base(salinityLevelQueryHandlerMagicStrings)
        {
            _salinityLevelQueryHandlerMagicStrings = salinityLevelQueryHandlerMagicStrings;
        }

        protected override SalinityLevelAnalysisResult Analyse(SalinityLevelAnalysis query, SalinityLevelAnalysisResult analysisResult)
        {
            return analysisResult;
        }

    }
}

namespace Auto.Aquaponics.Query.LevelAnalysis.Nitrite
{
    public class NitriteLevelQueryHandler : LevelQueryHandler<NitriteLevelAnalysis, NitriteLevelAnalysisResult>
    {
        private readonly INitriteLevelQueryHandlerMagicStrings _nitrateLevelQueryHandlerMagicStrings;

        public NitriteLevelQueryHandler(INitriteLevelQueryHandlerMagicStrings nitriteLevelQueryHandlerMagicStrings) : base(nitriteLevelQueryHandlerMagicStrings)
        {
            _nitrateLevelQueryHandlerMagicStrings = nitriteLevelQueryHandlerMagicStrings;
        }

        protected override NitriteLevelAnalysisResult Analyse(NitriteLevelAnalysis query, NitriteLevelAnalysisResult analysisResult)
        {
            return analysisResult;
        }
    }
}

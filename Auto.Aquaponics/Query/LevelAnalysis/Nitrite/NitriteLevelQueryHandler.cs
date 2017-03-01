using Auto.Aquaponics.Query.LevelAnalysis.Nitrate;

namespace Auto.Aquaponics.Query.LevelAnalysis.Nitrite
{
    public class NitriteLevelQueryHandler : LevelQueryHandler<NitrateLevelAnalysis, NitrateLevelAnalysisResult>
    {
        private readonly INitrateLevelQueryHandlerMagicStrings _nitrateLevelQueryHandlerMagicStrings;

        public NitriteLevelQueryHandler(INitrateLevelQueryHandlerMagicStrings nitrateLevelQueryHandlerMagicStrings) : base(nitrateLevelQueryHandlerMagicStrings)
        {
            _nitrateLevelQueryHandlerMagicStrings = nitrateLevelQueryHandlerMagicStrings;
        }

        protected override NitrateLevelAnalysisResult Analyse(NitrateLevelAnalysis query, NitrateLevelAnalysisResult analysisResult)
        {
            return analysisResult;
        }
    }
}

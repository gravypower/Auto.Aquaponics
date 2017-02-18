using Auto.Aquaponics.Aquarium.Query.Level.Nitrate;

namespace Auto.Aquaponics.Aquarium.Query.Level.Nitrite
{
    public class NitriteLevelQueryHandler : LevelQueryHandler<NitrateLevel, NitrateLevelAnalysis>
    {
        private readonly INitrateLevelQueryHandlerMagicStrings _nitrateLevelQueryHandlerMagicStrings;

        public NitriteLevelQueryHandler(INitrateLevelQueryHandlerMagicStrings nitrateLevelQueryHandlerMagicStrings) : base(nitrateLevelQueryHandlerMagicStrings)
        {
            _nitrateLevelQueryHandlerMagicStrings = nitrateLevelQueryHandlerMagicStrings;
        }

        protected override NitrateLevelAnalysis Analyse(NitrateLevel query, NitrateLevelAnalysis analysis)
        {
            return analysis;
        }
    }
}

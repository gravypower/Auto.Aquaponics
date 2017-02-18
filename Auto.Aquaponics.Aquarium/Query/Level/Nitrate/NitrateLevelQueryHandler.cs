namespace Auto.Aquaponics.Aquarium.Query.Level.Nitrate
{
    public class NitrateLevelQueryHandler: LevelQueryHandler<NitrateLevel, NitrateLevelAnalysis>
    {
        private readonly INitrateLevelQueryHandlerMagicStrings _nitrateLevelQueryHandlerMagicStrings;

        public NitrateLevelQueryHandler(INitrateLevelQueryHandlerMagicStrings nitrateLevelQueryHandlerMagicStrings) : base(nitrateLevelQueryHandlerMagicStrings)
        {
            _nitrateLevelQueryHandlerMagicStrings = nitrateLevelQueryHandlerMagicStrings;
        }

        protected override NitrateLevelAnalysis Analyse(NitrateLevel query, NitrateLevelAnalysis analysis)
        {
            return analysis;
        }

    }
}

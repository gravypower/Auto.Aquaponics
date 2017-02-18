namespace Auto.Aquaponics.Aquarium.Query.Level.Salinity
{
    public class SalinityLevelQueryHandler: LevelQueryHandler<SalinityLevel, SalinityLevelAnalysis>
    {
        private readonly ISalinityLevelQueryHandlerMagicStrings _salinityLevelQueryHandlerMagicStrings;

        public SalinityLevelQueryHandler(ISalinityLevelQueryHandlerMagicStrings salinityLevelQueryHandlerMagicStrings) : base(salinityLevelQueryHandlerMagicStrings)
        {
            _salinityLevelQueryHandlerMagicStrings = salinityLevelQueryHandlerMagicStrings;
        }

        protected override SalinityLevelAnalysis Analyse(SalinityLevel query, SalinityLevelAnalysis analysis)
        {
            return analysis;
        }

    }
}

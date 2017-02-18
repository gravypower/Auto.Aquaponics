namespace Auto.Aquaponics.Aquarium.Query.Level.Ammonia
{
    public class AmmoniaLevelQueryHandler: LevelQueryHandler<AmmoniaLevel, AmmoniaLevelAnalysis>
    {
        private readonly IAmmoniaLevelQueryHandlerMagicStrings _ammoniaLevelQueryHandlerMagicStrings;

        public AmmoniaLevelQueryHandler(IAmmoniaLevelQueryHandlerMagicStrings ammoniaLevelQueryHandlerMagicStrings) : base(ammoniaLevelQueryHandlerMagicStrings)
        {
            _ammoniaLevelQueryHandlerMagicStrings = ammoniaLevelQueryHandlerMagicStrings;
        }

        protected override AmmoniaLevelAnalysis Analyse(AmmoniaLevel query, AmmoniaLevelAnalysis analysis)
        {
            return analysis;
        }

    }
}

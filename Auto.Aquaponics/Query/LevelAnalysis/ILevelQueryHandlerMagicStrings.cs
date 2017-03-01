namespace Auto.Aquaponics.Query.LevelAnalysis
{
    public interface ILevelQueryHandlerMagicStrings
    {
        string OrganismNotDefinedExceptionMessage { get; }
        string OrganismTolerancesNotDefinedExceptionMessage { get; }
        string LevelKey { get; }
    }
}

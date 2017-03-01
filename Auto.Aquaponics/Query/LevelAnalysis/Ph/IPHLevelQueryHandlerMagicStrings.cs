namespace Auto.Aquaponics.Query.LevelAnalysis.Ph
{
    public interface IPhLevelQueryHandlerMagicStrings: ILevelQueryHandlerMagicStrings
    {
        string LowPhArgumentOutOfRangeExceptionMessage { get; }
        string HightPhArgumentOutOfRangeExceptionMessage { get; }
        string OrganismPhTolerancesNotDefinedExceptionMessage { get; }
    }
}

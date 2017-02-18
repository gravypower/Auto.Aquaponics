namespace Auto.Aquaponics.Aquarium.Query.Level.Ph
{
    public interface IPhLevelQueryHandlerMagicStrings: ILevelQueryHandlerMagicStrings
    {
        string LowPhArgumentOutOfRangeExceptionMessage { get; }
        string HightPhArgumentOutOfRangeExceptionMessage { get; }
        string OrganismPhTolerancesNotDefinedExceptionMessage { get; }
    }
}

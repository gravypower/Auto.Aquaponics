namespace Auto.Aquaponics.Analysis.Levels.Ph
{
    public interface IAnalysePhMagicStrings : ILevelMagicStrings
    {
        string LowPhArgumentOutOfRangeExceptionMessage { get; }
        string HightPhArgumentOutOfRangeExceptionMessage { get; }
        string OrganismPhTolerancesNotDefinedExceptionMessage { get; }
    }
}

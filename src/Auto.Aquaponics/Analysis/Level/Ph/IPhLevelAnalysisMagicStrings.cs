using Auto.Aquaponics.Analysis.Level;

namespace Auto.Aquaponics.Analysis.Level.Ph
{
    public interface IPhLevelAnalysisMagicStrings : ILevelMagicStrings
    {
        string LowPhArgumentOutOfRangeExceptionMessage { get; }
        string HightPhArgumentOutOfRangeExceptionMessage { get; }
        string OrganismPhTolerancesNotDefinedExceptionMessage { get; }
    }
}

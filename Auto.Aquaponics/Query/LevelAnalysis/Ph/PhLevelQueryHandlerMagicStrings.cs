namespace Auto.Aquaponics.Query.LevelAnalysis.Ph
{
    public class PhLevelQueryHandlerMagicStrings : LevelQueryHandlerMagicStrings, IPhLevelQueryHandlerMagicStrings
    {
        public string LowPhArgumentOutOfRangeExceptionMessage => "Reported ph is too low";
        public string HightPhArgumentOutOfRangeExceptionMessage => "Reported ph is too high";
        public string OrganismPhTolerancesNotDefinedExceptionMessage => "Organism pH tolerance not defined";
        public override string LevelKey => "pH";
    }
}

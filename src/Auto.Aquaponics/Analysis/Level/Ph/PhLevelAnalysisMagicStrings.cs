namespace Auto.Aquaponics.Analysis.Level.Ph
{
    public class PhLevelAnalysisMagicStrings : LevelAnalysisMagicStrings, IPhLevelAnalysisMagicStrings
    {
        public string LowPhArgumentOutOfRangeExceptionMessage => "Reported ph is too low";
        public string HightPhArgumentOutOfRangeExceptionMessage => "Reported ph is too high";
        public string OrganismPhTolerancesNotDefinedExceptionMessage => "Organism pH tolerance not defined";
        public override string LevelKey => "pH";
    }
}

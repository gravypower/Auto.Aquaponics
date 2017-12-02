namespace Ponics.Analysis.Levels.Ph
{
    public class AnalysePhMagicStrings : AnalyseMagicStrings, IAnalysePhMagicStrings
    {
        public string LowPhArgumentOutOfRangeExceptionMessage => "Reported ph is too low";
        public string HightPhArgumentOutOfRangeExceptionMessage => "Reported ph is too high";
        public string OrganismPhTolerancesNotDefinedExceptionMessage => "Organism pH tolerance not defined";
        public override string LevelsKey => "pH";
    }
}

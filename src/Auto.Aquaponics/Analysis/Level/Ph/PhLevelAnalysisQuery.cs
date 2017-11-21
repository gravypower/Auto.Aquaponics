namespace Auto.Aquaponics.Analysis.Level.Ph
{
    public class PhLevelAnalysisQuery : LevelAnalysisQuery<PhLevelAnalysis>
    {
        public PhLevelAnalysisQuery()
        {
        }

        public PhLevelAnalysisQuery(double value) : base(value)
        {
        }

        public override LevelAnalysisQuery<PhLevelAnalysis> Clone()
        {
            return new PhLevelAnalysisQuery(Value);
        }
    }
}

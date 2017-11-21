namespace Auto.Aquaponics.Analysis.Level.Salinity
{
    public class SalinityLevelAnalysisQuery : LevelAnalysisQuery<SalinityLevelAnalysis>
    {
        public SalinityLevelAnalysisQuery()
        {
        }

        public SalinityLevelAnalysisQuery(double value) : base(value)
        {
        }

        public override LevelAnalysisQuery<SalinityLevelAnalysis> Clone()
        {
            return new SalinityLevelAnalysisQuery(Value);
        }
    }
}

namespace Auto.Aquaponics.Analysis.Level.Ammonia
{
    public class AmmoniaLevelAnalysisQuery : LevelAnalysisQuery<AmmoniaLevelAnalysis>
    {
        public AmmoniaLevelAnalysisQuery()
        {
        }

        public AmmoniaLevelAnalysisQuery(double value) : base(value)
        {
        }

        public override LevelAnalysisQuery<AmmoniaLevelAnalysis> Clone()
        {
            return new AmmoniaLevelAnalysisQuery(Value);
        }
    }
}

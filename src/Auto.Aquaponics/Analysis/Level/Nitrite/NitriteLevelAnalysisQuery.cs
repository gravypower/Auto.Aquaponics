namespace Auto.Aquaponics.Analysis.Level.Nitrite
{
    public class NitriteLevelAnalysisQuery : LevelAnalysisQuery<NitriteLevelAnalysis>
    {
        public NitriteLevelAnalysisQuery()
        {
        }

        public NitriteLevelAnalysisQuery(double value) : base(value)
        {
        }

        public override LevelAnalysisQuery<NitriteLevelAnalysis> Clone()
        {
            return new NitriteLevelAnalysisQuery(Value);
        }
    }
}

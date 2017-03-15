using Auto.Aquaponics.Kernel.Query;

namespace Auto.Aquaponics.Analysis.Level
{
    public class LevelAnalysisQuery<TLevelAnalysis> : Query<TLevelAnalysis> 
        where TLevelAnalysis:LevelAnalysis
    {
        public Organisms.Organism Organism { get; set; }

        public double Value { get; }

        protected LevelAnalysisQuery()
        {
        }

        protected LevelAnalysisQuery(double value)
        {
            Value = value;
        }

        public LevelAnalysisQuery<TLevelAnalysis> Clone()
        {
            return new LevelAnalysisQuery<TLevelAnalysis>(Value);
        }
    }
}

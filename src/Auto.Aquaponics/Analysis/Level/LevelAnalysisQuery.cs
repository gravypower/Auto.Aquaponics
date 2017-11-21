using Auto.Aquaponics.Query;

namespace Auto.Aquaponics.Analysis.Level
{
    public abstract class LevelAnalysisQuery<TLevelAnalysis> : IQuery<TLevelAnalysis>
        where TLevelAnalysis : LevelAnalysis
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

        public abstract LevelAnalysisQuery<TLevelAnalysis> Clone();
    }
}

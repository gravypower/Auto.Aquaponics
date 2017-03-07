namespace Auto.Aquaponics.Query.LevelAnalysis
{
    public abstract class LevelAnalysisQuery : Kernel.Query.Query
    {
        public Organisms.Organism Organism { get; set; }

        public double Vaue { get; }

        protected LevelAnalysisQuery()
        {
        }

        protected LevelAnalysisQuery(double value)
        {
            Vaue = value;
        }

        protected LevelAnalysisQuery(Organisms.Organism organism)
        {
            Organism = organism;
        }

        protected LevelAnalysisQuery(double value, Organisms.Organism organism) : this(organism)
        {
            Vaue = value;
        }
    }
}

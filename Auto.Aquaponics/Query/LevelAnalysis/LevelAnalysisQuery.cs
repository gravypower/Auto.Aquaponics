using NodaTime;

namespace Auto.Aquaponics.Query.LevelAnalysis
{
    public abstract class LevelAnalysisQuery : Kernel.Query.Query
    {
        public ZonedDateTime DateTime { get; }
        public Organisms.Organism Organism { get; }

        public double Vaue { get; }

        public override string Key => DateTime.ToString();

        protected LevelAnalysisQuery()
        {
        }

        protected LevelAnalysisQuery(Organisms.Organism organism)
        {
            Organism = organism;
        }

        protected LevelAnalysisQuery(double value, Organisms.Organism organism) : this(organism)
        {
            Vaue = value;
        }

        protected LevelAnalysisQuery(double value, Organisms.Organism organism, ZonedDateTime dateTime) : this(value, organism)
        {
            DateTime = dateTime;
        }
    }
}

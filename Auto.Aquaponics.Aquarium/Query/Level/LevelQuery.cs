using NodaTime;

namespace Auto.Aquaponics.Aquarium.Query.Level
{
    public abstract class LevelQuery : Kernel.Query.Query
    {
        public ZonedDateTime DateTime { get; }
        public Organism.Organism Organism { get; }

        public double Vaue { get; }

        public override string Key => DateTime.ToString();
        public override string SystemKey { get; }

        protected LevelQuery()
        {
        }

        protected LevelQuery(Organism.Organism organism)
        {
            Organism = organism;
        }


        protected LevelQuery(double value, Organism.Organism organism) : this(organism)
        {
            Vaue = value;
        }

        protected LevelQuery(double value, Organism.Organism organism, ZonedDateTime dateTime) : this(value, organism)
        {
            DateTime = dateTime;
        }
    }
}

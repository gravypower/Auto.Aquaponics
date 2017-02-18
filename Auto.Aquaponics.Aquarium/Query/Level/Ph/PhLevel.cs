namespace Auto.Aquaponics.Aquarium.Query.Level.Ph
{
    public class PhLevel : LevelQuery
    {
        public PhLevel()
        {
        }

        public PhLevel(Organism.Organism organism) : base(organism)
        {
        }

        public PhLevel(double value, Organism.Organism organism) : base(value, organism)
        {
        }
    }
}

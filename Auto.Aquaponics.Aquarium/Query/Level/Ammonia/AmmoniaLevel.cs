namespace Auto.Aquaponics.Aquarium.Query.Level.Ammonia
{
    public class AmmoniaLevel : LevelQuery
    {
        public AmmoniaLevel()
        {
        }

        public AmmoniaLevel(Organism.Organism organism) : base(organism)
        {
        }

        public AmmoniaLevel(double value, Organism.Organism organism) : base(value, organism)
        {
        }
    }
}

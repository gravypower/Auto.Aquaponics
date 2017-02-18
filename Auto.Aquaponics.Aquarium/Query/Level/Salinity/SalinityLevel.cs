namespace Auto.Aquaponics.Aquarium.Query.Level.Salinity
{
    public class SalinityLevel : LevelQuery
    {
        public SalinityLevel()
        {
        }

        public SalinityLevel(Organism.Organism organism) : base(organism)
        {
        }

        public SalinityLevel(double value, Organism.Organism organism) : base(value, organism)
        {
        }
    }
}

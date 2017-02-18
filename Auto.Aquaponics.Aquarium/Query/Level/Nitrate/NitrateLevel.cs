namespace Auto.Aquaponics.Aquarium.Query.Level.Nitrate
{
    public class NitrateLevel : LevelQuery
    {
        public NitrateLevel()
        {
        }

        public NitrateLevel(Organism.Organism organism) : base(organism)
        {
        }

        public NitrateLevel(double value, Organism.Organism organism) : base(value, organism)
        {
        }
    }
}

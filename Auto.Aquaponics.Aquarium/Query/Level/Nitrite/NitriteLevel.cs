namespace Auto.Aquaponics.Aquarium.Query.Level.Nitrite
{
    public class NitriteLevel : LevelQuery
    {
        public NitriteLevel()
        {
        }

        public NitriteLevel(Organism.Organism organism) : base(organism)
        {
        }

        public NitriteLevel(double value, Organism.Organism organism) : base(value, organism)
        {
        }
    }
}

using Auto.Aquaponics.Organisms;
using System;

namespace Auto.Aquaponics.HardCodedData.Organisms
{
    public class Worm : Organism
    {
        public Worm() : base(Guid.NewGuid(), "Worm")
        {
        }
    }
}

using Auto.Aquaponics.Organisms;
using System;
using Auto.Aquaponics.Tolerances;

namespace Auto.Aquaponics.HardCodedData.Organisms
{
    public abstract class Fish : Organism
    {
        protected Fish(Guid id, string name):base(id, name)
        {
            Tolerances.Add(new SalinityTolerance(0, 0.02, 0, 0));
            Tolerances.Add(new PhTolerance( 6, 10, 6.5, 9));
            Tolerances.Add(new NitriteTolerance(0, 40, 0, 20));
            Tolerances.Add(new NitrateTolerance(0, 40, 0, 20));
            Tolerances.Add(new AmmoniaTolerance(0, 0.02, 0, 0));
        }
    }
}

using Auto.Aquaponics.Organisms;
using System;
using Auto.Aquaponics.Tolerances;

namespace Auto.Aquaponics.HardCodedData.Organisms
{
    public class Bacteria:Organism
    {
        protected Bacteria(Guid id, string name):base(id, name)
        {
            Tolerances.Add(new SalinityTolerance(0, 0.02, 0, 0));
            Tolerances.Add(new PhTolerance(6, 8.5, 6, 8.5));
            Tolerances.Add(new NitriteTolerance(0, 40, 0, 20));
            Tolerances.Add(new NitrateTolerance(0, 40, 0, 20));
            Tolerances.Add(new AmmoniaTolerance(0, 0.02, 0, 0));
        }
    }
}

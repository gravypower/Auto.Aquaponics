using System;
using Auto.Aquaponics.Organisms;
using Auto.Aquaponics.Tolerances;

namespace Auto.Aquaponics.HardCodedData.Organisms
{
    public class Nitrospira : Bacteria
    {
        public Nitrospira() : base(Guid.Parse("1c31691a2eba4733b331c77831e8d0f1"), "Nitrobacter sp")
        {
            Tolerances.Add(new PhTolerance(6, 8.5, 7.3, 7.5));
        }
    }
}

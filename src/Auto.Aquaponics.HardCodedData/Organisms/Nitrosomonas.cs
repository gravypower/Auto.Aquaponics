using System;
using Auto.Aquaponics.Organisms;
using Auto.Aquaponics.Tolerances;

namespace Auto.Aquaponics.HardCodedData.Organisms
{
    public class Nitrosomonas: Bacteria
    {
        public Nitrosomonas() : base(Guid.Parse("7227ab4569a145f6a8504a6181605b78"), "Nitrosomonas sp")
        {
            Tolerances.Add(new PhTolerance(6, 8.5, 7.8, 8));
        }
    }
}

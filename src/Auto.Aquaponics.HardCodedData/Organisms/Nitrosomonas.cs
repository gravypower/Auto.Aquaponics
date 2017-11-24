using System;
using Auto.Aquaponics.Organisms;

namespace Auto.Aquaponics.HardCodedData.Organisms
{
    public class Nitrosomonas: Bacteria
    {
        public Nitrosomonas() : base(Guid.Parse("7227ab4569a145f6a8504a6181605b78"), "Nitrosomonas sp")
        {
            AddTolerances(new Tolerance("pH", Scale.Ph, 6, 8.5, 7.8, 8));
        }
    }
}

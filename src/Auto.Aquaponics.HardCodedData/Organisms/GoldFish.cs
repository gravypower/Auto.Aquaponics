using System;
using Auto.Aquaponics.Organisms;
using Auto.Aquaponics.Tolerances;

namespace Auto.Aquaponics.HardCodedData.Organisms
{
    public class GoldFish : Fish
    {
        public GoldFish() : base(Guid.Parse("d1cb10210a5d4924bc8cca9f1f2a351e"), "Gold Fish")
        {
            Tolerances.Add(new PhTolerance(6, 10, 6.5, 8));
        }
    }
}

using Auto.Aquaponics.Kernel;
using Auto.Aquaponics.Organisms;

namespace Auto.Aquaponics.HardCodedData.Organisms
{
    public class GoldFish : Fish
    {
        public GoldFish() : base("Gold Fish")
        {
            AddTolerances(new Tolerance("pH", Scale.Ph, 6, 10, 6.5, 8));
        }
    }
}

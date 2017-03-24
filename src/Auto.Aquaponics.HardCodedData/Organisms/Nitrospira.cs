using Auto.Aquaponics.Kernel;
using Auto.Aquaponics.Organisms;

namespace Auto.Aquaponics.HardCodedData.Organisms
{
    public class Nitrospira : Bacteria
    {
        public Nitrospira() : base("Nitrobacter sp")
        {
            AddTolerances(new Tolerance("pH", Scale.Ph, 6, 8.5, 7.3, 7.5));
        }
    }
}

using Auto.Aquaponics.Kernel;
using Auto.Aquaponics.Organisms;

namespace Auto.Aquaponics.HardCodedData.Organisms
{
    public class Nitrosomonas: Bacteria
    {
        public Nitrosomonas() : base("Nitrosomonas sp")
        {
            AddTolerances(new Tolerance("pH", Scale.Ph, 6, 8.5, 7.8, 8));
        }
    }
}

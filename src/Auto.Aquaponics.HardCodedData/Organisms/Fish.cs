using Auto.Aquaponics.Analysis.Levels.Ammonia;
using Auto.Aquaponics.Analysis.Levels.Iron;
using Auto.Aquaponics.Analysis.Levels.Nitrate;
using Auto.Aquaponics.Analysis.Levels.Nitrite;
using Auto.Aquaponics.Analysis.Levels.Ph;
using Auto.Aquaponics.Analysis.Levels.Salinity;
using Auto.Aquaponics.Organisms;

namespace Auto.Aquaponics.HardCodedData.Organisms
{
    public abstract class Fish : Organism
    {
        protected Fish()
        {
            Tolerances.Add(new SalinityTolerance(0, 0.02, 0, 0));
            Tolerances.Add(new PhTolerance( 6, 10, 6.5, 9));
            Tolerances.Add(new NitriteTolerance(0, 40, 0, 20));
            Tolerances.Add(new NitrateTolerance(0, 40, 0, 20));
            Tolerances.Add(new AmmoniaTolerance(0, 0.02, 0, 0));
            Tolerances.Add(new IronTolerance(0, 0.3, 0, 0));
        }
    }
}

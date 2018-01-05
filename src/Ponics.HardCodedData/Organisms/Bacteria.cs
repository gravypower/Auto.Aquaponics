using Ponics.Organisms;
using Ponics.Organisms.Tolerances;

namespace Ponics.HardCodedData.Organisms
{
    public class Bacteria:Organism
    {
        protected Bacteria()
        {
            Tolerances.Add(new SalinityTolerance(0, 0.02, 0, 0));
            Tolerances.Add(new NitriteTolerance(0, 40, 0, 20));
            Tolerances.Add(new NitrateTolerance(0, 40, 0, 20));
            Tolerances.Add(new AmmoniaTolerance(0, 0.02, 0, 0));
        }
    }
}
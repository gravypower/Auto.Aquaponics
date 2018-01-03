using Ponics.Analysis.Levels.Ammonia;
using Ponics.Analysis.Levels.Nitrate;
using Ponics.Analysis.Levels.Nitrite;
using Ponics.Analysis.Levels.Salinity;
using Ponics.Organisms;

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
using System;
using Ponics.Analysis.Levels.Ph;

namespace Ponics.HardCodedData.Organisms
{
    public class Nitrospira : Bacteria
    {
        public Nitrospira()
        {
            Id = Guid.Parse("1c31691a2eba4733b331c77831e8d0f1");
            Name = "Nitrobacter sp";
            Tolerances.Add(new PhTolerance(6, 8.5, 7.3, 7.5));
        }
    }
}

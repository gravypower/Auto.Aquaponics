using System;
using Ponics.Organisms;
using Ponics.Analysis.Levels.Ph;

namespace Ponics.HardCodedData.Organisms
{
    public class Nitrosomonas: Bacteria
    {
        public Nitrosomonas()
        {
            Id = Guid.Parse("7227ab4569a145f6a8504a6181605b78");
            Name = "Nitrosomonas sp";
            Tolerances.Add(new PhTolerance(6, 8.5, 7.8, 8));
        }
    }
}

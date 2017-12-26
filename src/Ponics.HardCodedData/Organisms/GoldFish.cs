﻿using System;
using Ponics.Analysis.Levels.Ph;

namespace Ponics.HardCodedData.Organisms
{
    public class GoldFish : Fish
    {
        public GoldFish()
        {
            Id = Guid.Parse("d1cb10210a5d4924bc8cca9f1f2a351e");
            Name = "Gold Fish";
            Tolerances.Add(new PhTolerance(6, 10, 6.5, 8));
        }
    }
}

﻿using System.Collections.Generic;
using Auto.Aquaponics.Organisms;
using Auto.Aquaponics.HardCodedData.Organisms;
using NUnit.Framework;

namespace Auto.Aquaponics.Tests.Query.Level.Iron
{
    [TestFixture]
    public class SilverPerchIronTests : IronLevelAnalysisHandlerTests
    {
        protected override Organism GetOrganism()
        {
            return new SilverPerch();
        }

        protected override IEnumerable<double> Is_suitable_cases()
        {
            yield return 0;
            yield return .1;
            yield return .2;
        }

        protected override IEnumerable<double> Is_not_suitable_cases()
        {
            yield return .4;
        }

        protected override IEnumerable<double> Is_not_ideal_cases()
        {
            yield return 6;
        }

        protected override IEnumerable<double> Is_ideal_cases()
        {
            yield return 0;
        }

    }
}
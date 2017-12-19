using System.Collections.Generic;
using NUnit.Framework;
using Ponics.HardCodedData.Organisms;
using Ponics.Organisms;

namespace Ponics.Tests.Query.Level.Iron
{
    [TestFixture]
    public class SilverPerchIronTests : IronLevelAnalysisTests
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
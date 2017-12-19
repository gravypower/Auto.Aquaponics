using System.Collections.Generic;
using NUnit.Framework;
using Ponics.HardCodedData.Organisms;
using Ponics.Organisms;

namespace Ponics.Tests.Query.Level.Ammonia
{
    [TestFixture]
    public class SilverPerchAmmoniaTests: AmmoniaLevelAnalysisTests
    {
        protected override Organism GetOrganism()
        {
            return new SilverPerch();
        }

        protected override IEnumerable<double> Is_suitable_cases()
        {
            yield return 0;
        }

        protected override IEnumerable<double> Is_not_suitable_cases()
        {
            yield return 0.049;
        }

        protected override IEnumerable<double> Is_not_ideal_cases()
        {
            yield return 0.499;
        }

        protected override IEnumerable<double> Is_ideal_cases()
        {
            yield return 0;
        }
    }
}

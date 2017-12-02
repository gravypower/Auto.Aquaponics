using System.Collections.Generic;
using NUnit.Framework;
using Ponics.HardCodedData.Organisms;
using Ponics.Organisms;

namespace Ponics.Tests.Query.Level.Nitrate
{
    [TestFixture]
    public class SilverPerchNitrateTests: NitrateLevelAnalysisHandlerTests
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
            yield return 41;
        }

        protected override IEnumerable<double> Is_not_ideal_cases()
        {
            yield return 21;
        }

        protected override IEnumerable<double> Is_ideal_cases()
        {
            yield return 0;
        }
    }
}
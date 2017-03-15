using System.Collections.Generic;
using Auto.Aquaponics.Organisms;
using Auto.Aquaponics.Tests.Organisms;
using NUnit.Framework;

namespace Auto.Aquaponics.Tests.Query.Level.Salinity
{
    [TestFixture]
    public class SilverPerchSalinityTests: SalinityLevelAnalysisHandlerTests
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

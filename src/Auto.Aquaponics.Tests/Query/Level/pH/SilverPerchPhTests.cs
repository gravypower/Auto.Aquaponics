using System.Collections.Generic;
using Auto.Aquaponics.Organisms;
using Auto.Aquaponics.Tests.Organisms;
using NUnit.Framework;

namespace Auto.Aquaponics.Tests.Query.Level.pH
{
    [TestFixture]
    public class SilverPerchPhTests : PhLevelAnalysisHandlerTests
    {
        protected override Organism GetOrganism()
        {
            return new SilverPerch();
        }

        protected override IEnumerable<double> Is_suitable_cases()
        {
            yield return 6;
            yield return 10;
            yield return 9;
        }

        protected override IEnumerable<double> Is_not_suitable_cases()
        {
            yield return 0;
        }

        protected override IEnumerable<double> Is_not_ideal_cases()
        {
            yield return 6;
        }

        protected override IEnumerable<double> Is_ideal_cases()
        {
            yield return 6.5;
            yield return 9;
        }
    }
}
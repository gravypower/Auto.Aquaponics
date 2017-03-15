using System.Collections.Generic;
using Auto.Aquaponics.Organisms;
using Auto.Aquaponics.Tests.Organisms;
using NUnit.Framework;

namespace Auto.Aquaponics.Tests.Query.Level.Nitrite
{
    [TestFixture]
    public class SilverPerchNitriteTests: NitriteLevelAnalysisHandlerTests
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

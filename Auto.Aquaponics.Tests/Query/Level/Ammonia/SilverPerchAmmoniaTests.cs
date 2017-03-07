using System.Collections.Generic;
using Auto.Aquaponics.Kernel;
using Auto.Aquaponics.Organisms;
using NUnit.Framework;

namespace Auto.Aquaponics.Tests.Query.Level.Ammonia
{
    [TestFixture]
    public class SilverPerchAmmoniaTests: AmmoniaLevelQueryHandlerTests
    {
        protected override Tolerances GetTolerances()
        {
            return new Tolerances("Ammonia", Scale.Ppm, 0.02, 0, 0, 0);
        }

        protected override string GetOrganismName()
        {
            return "Silver Perch";
        }

        protected override IEnumerable<double> is_suitable_cases()
        {
            yield return 0;
        }

        protected override IEnumerable<double> is_not_suitable_cases()
        {
            yield return 0.049;
        }

        protected override IEnumerable<double> is_not_ideal_cases()
        {
            yield return 0.499;
        }

        protected override IEnumerable<double> is_ideal_cases()
        {
            yield return 0;
        }
    }
}

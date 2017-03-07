using System.Collections.Generic;
using Auto.Aquaponics.Kernel;
using Auto.Aquaponics.Organisms;
using NUnit.Framework;

namespace Auto.Aquaponics.Tests.Query.Level.Nitrite
{
    [TestFixture]
    public class SilverPerchNitriteTests: NitriteLevelQueryHandlerTests
    {
        protected override Tolerances GetTolerances()
        {
            return new Tolerances("Nitrite", Scale.Ppm, 40, 0, 20, 0);
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
            yield return 41;
        }

        protected override IEnumerable<double> is_not_ideal_cases()
        {
            yield return 21;
        }

        protected override IEnumerable<double> is_ideal_cases()
        {
            yield return 0;
        }
    }
}

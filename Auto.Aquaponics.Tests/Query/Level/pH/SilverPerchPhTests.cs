using System.Collections.Generic;
using Auto.Aquaponics.Kernel;
using Auto.Aquaponics.Organisms;
using NUnit.Framework;

namespace Auto.Aquaponics.Tests.Query.Level.pH
{
    [TestFixture]
    public class SilverPerchPhTests : PhLevelQueryHandlerTests
    {
        protected override string GetOrganismName()
        {
            return "Silver Perch";
        }

        protected override Tolerances GetTolerances()
        {
            return new Tolerances(LevelQueryHandlerMagicStrings.LevelKey, Scale.Ph, 10, 6, 9, 6.5);
        }

        protected override IEnumerable<double> is_suitable_cases()
        {
            yield return 6;
            yield return 10;
            yield return 9;
        }

        protected override IEnumerable<double> is_not_suitable_cases()
        {
            yield return 0;
        }

        protected override IEnumerable<double> is_not_ideal_cases()
        {
            yield return 6;
        }

        protected override IEnumerable<double> is_ideal_cases()
        {
            yield return 6.5;
            yield return 9;
        }
    }
}
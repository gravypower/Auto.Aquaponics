using Auto.Aquaponics.Kernel;
using Auto.Aquaponics.Organisms;
using Auto.Aquaponics.Query.LevelAnalysis.Nitrate;
using FluentAssertions;
using NUnit.Framework;

namespace Auto.Aquaponics.Tests.Query.Level.Nitrate
{
    [TestFixture]
    public class SilverPerchNitrateTests: NitrateLevelQueryHandlerTests
    {
        protected override Tolerances GetTolerances()
        {
            return new Tolerances("Nitrate", Scale.Ppm, 40, 0, 20, 0);
        }

        protected override string GetOrganismName()
        {
            return "Silver Perch";
        }

        [TestCase(0)]
        public void is_suitable(double level)
        {
            var query = new NitrateLevelAnalysis(level, Organism);

            var result = Sut.Handle(query);
            result.SutablalForOrganism.Should().BeTrue();
        }

        [TestCase(41)]
        public void is_not_suitable(double level)
        {
            var query = new NitrateLevelAnalysis(level, Organism);

            var result = Sut.Handle(query);
            result.SutablalForOrganism.Should().BeFalse();
        }


        [TestCase(21)]
        public void is_not_ideal(double level)
        {
            var query = new NitrateLevelAnalysis(level, Organism);

            var result = Sut.Handle(query);
            result.IdealForOrganism.Should().BeFalse();
        }

        [TestCase(0)]
        public void is_ideal(double level)
        {
            var query = new NitrateLevelAnalysis(level, Organism);

            var result = Sut.Handle(query);
            result.IdealForOrganism.Should().BeTrue();
        }
    }
}
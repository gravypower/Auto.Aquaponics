using Auto.Aquaponics.Aquarium.Query.Level.Salinity;
using Auto.Aquaponics.Organism;
using FluentAssertions;
using NUnit.Framework;

namespace Auto.Aquaponics.Aquarium.Tests.Query.Level.Salinity
{
    [TestFixture]
    public class SilverPerchSalinityTests: SalinityLevelQueryHandlerTests
    {
        protected override Tolerances GetTolerances()
        {
            return new Tolerances("Salinity", Scale.ppm, 0.02, 0, 0, 0);
        }

        protected override string GetOrganismName()
        {
            return "Silver Perch";
        }

        [TestCase(0)]
        public void is_suitable(double level)
        {
            var query = new SalinityLevel(level, Organism);

            var result = Sut.Handle(query);
            result.SutablalForOrganism.Should().BeTrue();
        }

        [TestCase(0.049)]
        public void is_not_suitable(double level)
        {
            var query = new SalinityLevel(level, Organism);

            var result = Sut.Handle(query);
            result.SutablalForOrganism.Should().BeFalse();
        }

        [TestCase(0.499)]
        public void is_not_ideal(double level)
        {
            var query = new SalinityLevel(level, Organism);

            var result = Sut.Handle(query);
            result.IdealForOrganism.Should().BeFalse();
        }

        [TestCase(0)]
        public void is_ideal(double level)
        {
            var query = new SalinityLevel(level, Organism);

            var result = Sut.Handle(query);
            result.IdealForOrganism.Should().BeTrue();
        }
    }
}

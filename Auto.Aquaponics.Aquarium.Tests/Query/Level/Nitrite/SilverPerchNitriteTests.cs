using Auto.Aquaponics.Aquarium.Query.Level.Nitrate;
using Auto.Aquaponics.Organism;
using FluentAssertions;
using NUnit.Framework;

namespace Auto.Aquaponics.Aquarium.Tests.Query.Level.Nitrite
{
    [TestFixture]
    public class SilverPerchNitriteTests: NitriteLevelQueryHandlerTests
    {
        protected override Tolerances GetTolerances()
        {
            return new Tolerances("Nitrite", Scale.ppm, 40, 0, 20, 0);
        }

        protected override string GetOrganismName()
        {
            return "Silver Perch";
        }

        [TestCase(0)]
        public void is_suitable(double level)
        {
            var query = new NitrateLevel(level, Organism);

            var result = Sut.Handle(query);
            result.SutablalForOrganism.Should().BeTrue();
        }

        [TestCase(41)]
        public void is_not_suitable(double level)
        {
            var query = new NitrateLevel(level, Organism);

            var result = Sut.Handle(query);
            result.SutablalForOrganism.Should().BeFalse();
        }


        [TestCase(21)]
        public void is_not_ideal(double level)
        {
            var query = new NitrateLevel(level, Organism);

            var result = Sut.Handle(query);
            result.IdealForOrganism.Should().BeFalse();
        }

        [TestCase(0)]
        public void is_ideal(double level)
        {
            var query = new NitrateLevel(level, Organism);

            var result = Sut.Handle(query);
            result.IdealForOrganism.Should().BeTrue();
        }
    }
}

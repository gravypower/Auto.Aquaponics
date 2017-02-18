using Auto.Aquaponics.Aquarium.Query.Level.Ph;
using Auto.Aquaponics.Organism;
using FluentAssertions;
using NUnit.Framework;

namespace Auto.Aquaponics.Aquarium.Tests.Query.Level.pH
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
            return new Tolerances(LevelQueryHandlerMagicStrings.LevelKey, Scale.pH, 10, 6, 9, 6.5);
        }

        [TestCase(0)]
        public void is_not_suitable(double level)
        {
            var query = new PhLevel(level, Organism);

            var result = Sut.Handle(query);
            result.SutablalForOrganism.Should().BeFalse();
        }

        [TestCase(6)]
        [TestCase(10)]
        [TestCase(9)]
        public void is_suitable(double level)
        {
            var query = new PhLevel(level, Organism);

            var result = Sut.Handle(query);
            result.SutablalForOrganism.Should().BeTrue();
        }

        [TestCase(6)]
        public void is_not_ideal(double level)
        {
            var query = new PhLevel(level, Organism);

            var result = Sut.Handle(query);
            result.IdealForOrganism.Should().BeFalse();
        }

        [TestCase(6.5)]
        [TestCase(9)]
        public void is_ideal(double level)
        {
            var query = new PhLevel(level, Organism);

            var result = Sut.Handle(query);
            result.IdealForOrganism.Should().BeTrue();
        }
    }
}
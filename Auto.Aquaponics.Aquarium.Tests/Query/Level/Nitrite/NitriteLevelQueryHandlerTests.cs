using Auto.Aquaponics.Aquarium.Query.Level.Nitrate;
using NSubstitute;
using NUnit.Framework;

namespace Auto.Aquaponics.Aquarium.Tests.Query.Level.Nitrite
{
    public abstract class NitriteLevelQueryHandlerTests: LevelQueryHandlerTests<
            NitrateLevelQueryHandler,
            INitrateLevelQueryHandlerMagicStrings,
            NitrateLevel,
            NitrateLevelAnalysis
        >
    {

        [SetUp]
        protected void NitriteLevelQueryHandlerTestsSetUp()
        {
            LevelQueryHandlerMagicStrings.LevelKey.Returns("Nitrite");

            Organism = Substitute.For<Organism.Organism>(GetOrganismName());
            Organism.AddTolerances(GetTolerances());

            Sut = new NitrateLevelQueryHandler(LevelQueryHandlerMagicStrings);
        }

    }
}

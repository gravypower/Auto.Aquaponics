using Auto.Aquaponics.Aquarium.Query.Level.Nitrate;
using NSubstitute;
using NUnit.Framework;

namespace Auto.Aquaponics.Aquarium.Tests.Query.Level.Nitrate
{
    public abstract class NitrateLevelQueryHandlerTests: LevelQueryHandlerTests<
            NitrateLevelQueryHandler,
            INitrateLevelQueryHandlerMagicStrings,
            NitrateLevel,
            NitrateLevelAnalysis
        >
    {

        [SetUp]
        protected void NitrateLevelQueryHandlerTestsSetUp()
        {
            LevelQueryHandlerMagicStrings.LevelKey.Returns("Nitrate");

            Organism = Substitute.For<Organism.Organism>(GetOrganismName());
            Organism.AddTolerances(GetTolerances());

            Sut = new NitrateLevelQueryHandler(LevelQueryHandlerMagicStrings);
        }

    }
}

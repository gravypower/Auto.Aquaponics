using Auto.Aquaponics.Aquarium.Query.Level.Salinity;
using NSubstitute;
using NUnit.Framework;

namespace Auto.Aquaponics.Aquarium.Tests.Query.Level.Salinity
{
    public abstract class SalinityLevelQueryHandlerTests : LevelQueryHandlerTests<
            SalinityLevelQueryHandler,
            ISalinityLevelQueryHandlerMagicStrings,
            SalinityLevel,
            SalinityLevelAnalysis
        >
    {

        [SetUp]
        protected void NitrateLevelQueryHandlerTestsSetUp()
        {
            LevelQueryHandlerMagicStrings.LevelKey.Returns("Salinity");

            Organism = Substitute.For<Organism.Organism>(GetOrganismName());
            Organism.AddTolerances(GetTolerances());

            Sut = new SalinityLevelQueryHandler(LevelQueryHandlerMagicStrings);
        }

    }
}

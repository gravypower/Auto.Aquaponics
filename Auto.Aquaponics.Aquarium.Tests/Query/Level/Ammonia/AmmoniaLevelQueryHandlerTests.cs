using Auto.Aquaponics.Aquarium.Query.Level.Ammonia;
using NSubstitute;
using NUnit.Framework;

namespace Auto.Aquaponics.Aquarium.Tests.Query.Level.Ammonia
{
    public abstract class AmmoniaLevelQueryHandlerTests: LevelQueryHandlerTests<
            AmmoniaLevelQueryHandler,
            IAmmoniaLevelQueryHandlerMagicStrings,
            AmmoniaLevel,
            AmmoniaLevelAnalysis
        >
    {

        [SetUp]
        protected void NitrateLevelQueryHandlerTestsSetUp()
        {
            LevelQueryHandlerMagicStrings.LevelKey.Returns("Ammonia");

            Organism = Substitute.For<Organism.Organism>(GetOrganismName());
            Organism.AddTolerances(GetTolerances());

            Sut = new AmmoniaLevelQueryHandler(LevelQueryHandlerMagicStrings);
        }

    }
}

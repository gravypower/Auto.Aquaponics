using Auto.Aquaponics.Query.LevelAnalysis.Ammonia;
using NSubstitute;
using NUnit.Framework;

namespace Auto.Aquaponics.Tests.Query.Level.Ammonia
{
    public abstract class AmmoniaLevelQueryHandlerTests: LevelQueryHandlerTests<
            AmmoniaLevelQueryHandler,
            IAmmoniaLevelQueryHandlerMagicStrings,
            AmmoniaLevelAnalysis,
            AmmoniaLevelAnalysisResult
        >
    {

        [SetUp]
        protected void NitrateLevelQueryHandlerTestsSetUp()
        {
            LevelQueryHandlerMagicStrings.LevelKey.Returns("Ammonia");

            Organism = Substitute.For<Organisms.Organism>(GetOrganismName());
            Organism.AddTolerances(GetTolerances());

            Sut = new AmmoniaLevelQueryHandler(LevelQueryHandlerMagicStrings);
        }

    }
}

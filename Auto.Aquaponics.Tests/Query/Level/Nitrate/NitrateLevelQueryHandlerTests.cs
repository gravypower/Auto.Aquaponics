using Auto.Aquaponics.Query.LevelAnalysis.Nitrate;
using NSubstitute;
using NUnit.Framework;

namespace Auto.Aquaponics.Tests.Query.Level.Nitrate
{
    public abstract class NitrateLevelQueryHandlerTests: LevelQueryHandlerTests<
            NitrateLevelQueryHandler,
            INitrateLevelQueryHandlerMagicStrings,
            NitrateLevelAnalysis,
            NitrateLevelAnalysisResult
        >
    {

        [SetUp]
        protected void NitrateLevelQueryHandlerTestsSetUp()
        {
            LevelQueryHandlerMagicStrings.LevelKey.Returns("Nitrate");

            Organism = Substitute.For<Organisms.Organism>(GetOrganismName());
            Organism.AddTolerances(GetTolerances());

            Sut = new NitrateLevelQueryHandler(LevelQueryHandlerMagicStrings);
        }

    }
}

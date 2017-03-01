using Auto.Aquaponics.Query.LevelAnalysis.Nitrate;
using NSubstitute;
using NUnit.Framework;

namespace Auto.Aquaponics.Tests.Query.Level.Nitrite
{
    public abstract class NitriteLevelQueryHandlerTests: LevelQueryHandlerTests<
            NitrateLevelQueryHandler,
            INitrateLevelQueryHandlerMagicStrings,
            NitrateLevelAnalysis,
            NitrateLevelAnalysisResult
        >
    {

        [SetUp]
        protected void NitriteLevelQueryHandlerTestsSetUp()
        {
            LevelQueryHandlerMagicStrings.LevelKey.Returns("Nitrite");

            Organism = Substitute.For<Organisms.Organism>(GetOrganismName());
            Organism.AddTolerances(GetTolerances());

            Sut = new NitrateLevelQueryHandler(LevelQueryHandlerMagicStrings);
        }

    }
}

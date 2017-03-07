using Auto.Aquaponics.Query.LevelAnalysis.Nitrite;
using NSubstitute;
using NUnit.Framework;

namespace Auto.Aquaponics.Tests.Query.Level.Nitrite
{
    public abstract class NitriteLevelQueryHandlerTests: LevelQueryHandlerTests<
            NitriteLevelQueryHandler,
            INitriteLevelQueryHandlerMagicStrings,
            NitriteLevelAnalysis,
            NitriteLevelAnalysisResult
        >
    {

        [SetUp]
        protected void NitriteLevelQueryHandlerTestsSetUp()
        {
            LevelQueryHandlerMagicStrings.LevelKey.Returns("Nitrite");

            Organism = Substitute.For<Organisms.Organism>(GetOrganismName());
            Organism.AddTolerances(GetTolerances());

            Sut = new NitriteLevelQueryHandler(LevelQueryHandlerMagicStrings);
        }

    }
}

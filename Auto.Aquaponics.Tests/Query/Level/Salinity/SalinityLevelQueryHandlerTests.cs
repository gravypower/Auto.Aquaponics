using Auto.Aquaponics.Organisms;
using Auto.Aquaponics.Query.LevelAnalysis.Salinity;
using NSubstitute;
using NUnit.Framework;

namespace Auto.Aquaponics.Tests.Query.Level.Salinity
{
    public abstract class SalinityLevelQueryHandlerTests : LevelQueryHandlerTests<
            SalinityLevelQueryHandler,
            ISalinityLevelQueryHandlerMagicStrings,
            SalinityLevelAnalysis,
            SalinityLevelAnalysisResult
        >
    {

        [SetUp]
        protected void SalinityLevelQueryHandlerTestsSetUp()
        {
            LevelQueryHandlerMagicStrings.LevelKey.Returns("Salinity");

            Organism = Substitute.For<Organism>(GetOrganismName());
            Organism.AddTolerances(GetTolerances());

            Sut = new SalinityLevelQueryHandler(LevelQueryHandlerMagicStrings);
        }

    }
}

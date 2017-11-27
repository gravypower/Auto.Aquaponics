using Auto.Aquaponics.Analysis.Levels.Salinity;
using NSubstitute;

namespace Auto.Aquaponics.Tests.Query.Level.Salinity
{
    public abstract class SalinityLevelAnalysisHandlerTests : LevelAnalysisHandlerTests<
            AnalyseSalinityQueryHandler,
            IAnalyseSalinityMagicStrings,
            AnalyseSalinity,
            SalinityAnalysis,
            SalinityTolerance
        >
    {

        protected override void DoSetUp()
        {
            LevelQueryHandlerMagicStrings.LevelsKey.Returns("Salinity");
            Sut = new AnalyseSalinityQueryHandler(LevelQueryHandlerMagicStrings, GetAllOrganismsDataQueryHandler);
        }

    }
}

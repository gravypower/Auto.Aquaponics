using Auto.Aquaponics.Analysis.Levels.Salinity;
using NSubstitute;

namespace Auto.Aquaponics.Tests.Query.Level.Salinity
{
    public abstract class SalinityLevelAnalysisHandlerTests : LevelAnalysisHandlerTests<
            AnalyseSalinityQueryHandler,
            IAnalyseSalinityMagicStrings,
            AnalyseSalinity,
            SalinityAnalysis
        >
    {

        protected override void DoSetUp()
        {
            LevelQueryHandlerMagicStrings.LevelKey.Returns("Salinity");
            Sut = new AnalyseSalinityQueryHandler(LevelQueryHandlerMagicStrings, GetAllOrganismsDataQueryHandler);
        }

    }
}

using NSubstitute;
using Ponics.Analysis.Levels.Salinity;

namespace Ponics.Tests.Query.Level.Salinity
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
            Sut = new AnalyseSalinityQueryHandler(LevelQueryHandlerMagicStrings, GetAllOrganismsDataQueryHandler);
        }

    }
}

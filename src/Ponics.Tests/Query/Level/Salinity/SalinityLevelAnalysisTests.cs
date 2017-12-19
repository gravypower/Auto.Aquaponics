using NSubstitute;
using Ponics.Analysis.Levels.Salinity;

namespace Ponics.Tests.Query.Level.Salinity
{
    public abstract class SalinityLevelAnalysisTests : LevelAnalysisTests<
            AnalyseSalinityQueryHandler,
            IAnalyseSalinityMagicStrings,
            AnalyseToleranceSalinity,
            SalinityToleranceAnalysis,
            SalinityTolerance
        >
    {

        protected override void DoSetUp()
        {
            Sut = new AnalyseSalinityQueryHandler(LevelQueryHandlerMagicStrings, GetAllOrganismsDataQueryHandler);
        }

    }
}

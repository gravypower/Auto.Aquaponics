using Auto.Aquaponics.Analysis.Level.Salinity;
using NSubstitute;
using NUnit.Framework;

namespace Auto.Aquaponics.Tests.Query.Level.Salinity
{
    public abstract class SalinityLevelAnalysisHandlerTests : LevelAnalysisHandlerTests<
            SalinityLevelAnalysisQueryHandler,
            ISalinityLevelAnalysisMagicStrings,
            SalinityLevelAnalysisQuery,
            SalinityLevelAnalysis
        >
    {

        protected override void DoSetUp()
        {
            LevelQueryHandlerMagicStrings.LevelKey.Returns("Salinity");
            Sut = new SalinityLevelAnalysisQueryHandler(LevelQueryHandlerMagicStrings);
        }

    }
}

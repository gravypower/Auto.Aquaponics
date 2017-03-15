using Auto.Aquaponics.Analysis.Level.Nitrite;
using NSubstitute;
using NUnit.Framework;

namespace Auto.Aquaponics.Tests.Query.Level.Nitrite
{
    public abstract class NitriteLevelAnalysisHandlerTests: LevelAnalysisHandlerTests<
            NitriteLevelAnalysisQueryHandler,
            INitriteLevelAnalysisMagicStrings,
            NitriteLevelAnalysisQuery,
            NitriteLevelAnalysis
        >
    {

        protected override void DoSetUp()
        {
            LevelQueryHandlerMagicStrings.LevelKey.Returns("Nitrite");
            Sut = new NitriteLevelAnalysisQueryHandler(LevelQueryHandlerMagicStrings);
        }

    }
}

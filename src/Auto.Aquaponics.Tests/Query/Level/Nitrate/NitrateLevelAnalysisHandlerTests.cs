using Auto.Aquaponics.Analysis.Level.Nitrate;
using NSubstitute;

namespace Auto.Aquaponics.Tests.Query.Level.Nitrate
{
    public abstract class NitrateLevelAnalysisHandlerTests: LevelAnalysisHandlerTests<
            NitrateLevelAnalysisQueryHandler,
            INitrateLevelAnalysisMagicStrings,
            NitrateLevelAnalysisQuery,
            NitrateLevelAnalysis
        >
    {

        protected override void DoSetUp()
        {
            LevelQueryHandlerMagicStrings.LevelKey.Returns("Nitrate");
            Sut = new NitrateLevelAnalysisQueryHandler(LevelQueryHandlerMagicStrings);
        }

    }
}

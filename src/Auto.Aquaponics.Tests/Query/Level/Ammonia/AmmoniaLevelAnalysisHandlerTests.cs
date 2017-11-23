using Auto.Aquaponics.Analysis.Level.Ammonia;
using NSubstitute;

namespace Auto.Aquaponics.Tests.Query.Level.Ammonia
{
    public abstract class AmmoniaLevelAnalysisHandlerTests: LevelAnalysisHandlerTests<
            AmmoniaLevelAnalysisQueryHandler,
            IAmmoniaLevelAnalysisMagicStrings,
            AmmoniaLevelAnalysisQuery,
            AmmoniaLevelAnalysis
        >
    {
        protected override void DoSetUp()
        {
            LevelQueryHandlerMagicStrings.LevelKey.Returns("Ammonia");
            Sut = new AmmoniaLevelAnalysisQueryHandler(LevelQueryHandlerMagicStrings, Organisms);
        }

    }
}

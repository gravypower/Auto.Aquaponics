using Auto.Aquaponics.Analysis.Levels.Nitrite;
using NSubstitute;

namespace Auto.Aquaponics.Tests.Query.Level.Nitrite
{
    public abstract class NitriteLevelAnalysisHandlerTests: LevelAnalysisHandlerTests<
            AnalyseNitriteQueryHandler,
            IAnalyseNitriteMagicStrings,
            AnalyseNitrite,
            NitriteAnalysis,
            NitriteTolerance
        >
    {

        protected override void DoSetUp()
        {
            LevelQueryHandlerMagicStrings.LevelsKey.Returns("Nitrite");
            Sut = new AnalyseNitriteQueryHandler(LevelQueryHandlerMagicStrings, GetAllOrganismsDataQueryHandler);
        }

    }
}

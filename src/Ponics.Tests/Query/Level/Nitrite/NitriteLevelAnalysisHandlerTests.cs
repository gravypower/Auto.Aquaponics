using NSubstitute;
using Ponics.Analysis.Levels.Nitrite;

namespace Ponics.Tests.Query.Level.Nitrite
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

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
            Sut = new AnalyseNitriteQueryHandler(LevelQueryHandlerMagicStrings, GetAllOrganismsDataQueryHandler);
        }

    }
}

using NSubstitute;
using Ponics.Analysis.Levels.Nitrite;

namespace Ponics.Tests.Query.Level.Nitrite
{
    public abstract class NitriteLevelAnalysisTests: LevelAnalysisTests<
            AnalyseNitriteQueryHandler,
            IAnalyseNitriteMagicStrings,
            AnalyseToleranceNitrite,
            NitriteToleranceAnalysis,
            NitriteTolerance
        >
    {

        protected override void DoSetUp()
        {
            Sut = new AnalyseNitriteQueryHandler(LevelQueryHandlerMagicStrings, GetAllOrganismsDataQueryHandler);
        }

    }
}

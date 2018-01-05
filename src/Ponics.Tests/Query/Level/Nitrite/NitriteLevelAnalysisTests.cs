using NSubstitute;
using Ponics.Analysis.Levels.Nitrite;
using Ponics.Organisms.Tolerances;

namespace Ponics.Tests.Query.Level.Nitrite
{
    public abstract class NitriteLevelAnalysisTests: LevelAnalysisTests<
            AnalyseNitriteQueryHandler,
            IAnalyseNitriteMagicStrings,
            AnalyseToleranceNitrite,
            NitriteLevelAnalysis,
            NitriteTolerance
        >
    {

        protected override void DoSetUp()
        {
            Sut = new AnalyseNitriteQueryHandler(LevelQueryHandlerMagicStrings, GetAllOrganismsDataQueryHandler);
        }

    }
}

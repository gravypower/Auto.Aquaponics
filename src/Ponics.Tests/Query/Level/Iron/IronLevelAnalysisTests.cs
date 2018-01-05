using NSubstitute;
using Ponics.Analysis.Levels.Iron;
using Ponics.Organisms.Tolerances;

namespace Ponics.Tests.Query.Level.Iron
{
    public abstract class IronLevelAnalysisTests:
    LevelAnalysisTests<
    AnalyseIronQueryHandler,
    IAnalyseIronMagicStrings,
    AnalyseToleranceIron,
    IronLevelAnalysis,
    IronTolerance
    >
    {

        protected override void DoSetUp()
        {
            Sut = new AnalyseIronQueryHandler(LevelQueryHandlerMagicStrings, GetAllOrganismsDataQueryHandler);
        }
    }
}

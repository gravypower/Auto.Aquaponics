using NSubstitute;
using Ponics.Analysis.Levels.Nitrate;

namespace Ponics.Tests.Query.Level.Nitrate
{
    public abstract class NitrateLevelAnalysisTests: LevelAnalysisTests<
            AnalyseNitrateQueryHandler,
            IAnalyseNitrateMagicStrings,
            AnalyseToleranceNitrate,
            NitrateLevelAnalysis,
            NitrateTolerance
        >
    {

        protected override void DoSetUp()
        {
            Sut = new AnalyseNitrateQueryHandler(LevelQueryHandlerMagicStrings, GetAllOrganismsDataQueryHandler);
        }

    }
}

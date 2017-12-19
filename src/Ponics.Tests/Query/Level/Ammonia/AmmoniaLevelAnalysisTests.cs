using NSubstitute;
using Ponics.Analysis.Levels.Ammonia;

namespace Ponics.Tests.Query.Level.Ammonia
{
    public abstract class AmmoniaLevelAnalysisTests: LevelAnalysisTests<
            AnalyseAmmoniaQueryHandler,
            IAnalyseAmmoniaMagicStrings,
            AnalyseToleranceAmmonia,
            AmmoniaToleranceAnalysis,
            AmmoniaTolerance
        >
    {
        protected override void DoSetUp()
        {
            Sut = new AnalyseAmmoniaQueryHandler(LevelQueryHandlerMagicStrings, GetAllOrganismsDataQueryHandler);
        }

    }
}

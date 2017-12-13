using NSubstitute;
using Ponics.Analysis.Levels.Ammonia;

namespace Ponics.Tests.Query.Level.Ammonia
{
    public abstract class AmmoniaLevelAnalysisHandlerTests: LevelAnalysisHandlerTests<
            AnalyseAmmoniaQueryHandler,
            IAnalyseAmmoniaMagicStrings,
            AnalyseAmmonia,
            AmmoniaAnalysis,
            AmmoniaTolerance
        >
    {
        protected override void DoSetUp()
        {
            Sut = new AnalyseAmmoniaQueryHandler(LevelQueryHandlerMagicStrings, GetAllOrganismsDataQueryHandler);
        }

    }
}

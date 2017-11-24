using Auto.Aquaponics.Analysis.Levels.Ammonia;
using NSubstitute;

namespace Auto.Aquaponics.Tests.Query.Level.Ammonia
{
    public abstract class AmmoniaLevelAnalysisHandlerTests: LevelAnalysisHandlerTests<
            AnalyseAmmoniaQueryHandler,
            IAnalyseAmmoniaMagicStrings,
            AnalyseAmmonia,
            AmmoniaAnalysis
        >
    {
        protected override void DoSetUp()
        {
            LevelQueryHandlerMagicStrings.LevelKey.Returns("Ammonia");
            Sut = new AnalyseAmmoniaQueryHandler(LevelQueryHandlerMagicStrings, GetAllOrganismsDataQueryHandler);
        }

    }
}

using Auto.Aquaponics.Analysis.Levels.Ammonia;
using Auto.Aquaponics.Tolerances;
using NSubstitute;

namespace Auto.Aquaponics.Tests.Query.Level.Ammonia
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
            LevelQueryHandlerMagicStrings.LevelsKey.Returns("Ammonia");
            Sut = new AnalyseAmmoniaQueryHandler(LevelQueryHandlerMagicStrings, GetAllOrganismsDataQueryHandler);
        }

    }
}

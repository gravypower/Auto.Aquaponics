using Auto.Aquaponics.Analysis.Levels.Nitrate;
using NSubstitute;

namespace Auto.Aquaponics.Tests.Query.Level.Nitrate
{
    public abstract class NitrateLevelAnalysisHandlerTests: LevelAnalysisHandlerTests<
            AnalyseNitrateQueryHandler,
            IAnalyseNitrateMagicStrings,
            AnalyseNitrate,
            NitrateAnalysis,
            NitrateTolerance
        >
    {

        protected override void DoSetUp()
        {
            LevelQueryHandlerMagicStrings.LevelsKey.Returns("Nitrate");
            Sut = new AnalyseNitrateQueryHandler(LevelQueryHandlerMagicStrings, GetAllOrganismsDataQueryHandler);
        }

    }
}

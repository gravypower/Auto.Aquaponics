using Auto.Aquaponics.Analysis.Levels.Nitrite;
using NSubstitute;
using NUnit.Framework;

namespace Auto.Aquaponics.Tests.Query.Level.Nitrite
{
    public abstract class NitriteLevelAnalysisHandlerTests: LevelAnalysisHandlerTests<
            AnalyseNitriteQueryHandler,
            IAnalyseNitriteMagicStrings,
            AnalyseNitrite,
            NitriteAnalysis
        >
    {

        protected override void DoSetUp()
        {
            LevelQueryHandlerMagicStrings.LevelKey.Returns("Nitrite");
            Sut = new AnalyseNitriteQueryHandler(LevelQueryHandlerMagicStrings, GetAllOrganismsDataQueryHandler);
        }

    }
}

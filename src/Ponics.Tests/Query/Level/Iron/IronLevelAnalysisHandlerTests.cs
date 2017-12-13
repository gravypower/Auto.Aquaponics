﻿using NSubstitute;
using Ponics.Analysis.Levels.Iron;

namespace Ponics.Tests.Query.Level.Iron
{
    public abstract class IronLevelAnalysisHandlerTests:
    LevelAnalysisHandlerTests<
    AnalyseIronQueryHandler,
    IAnalyseIronMagicStrings,
    AnalyseIron,
    IronAnalysis,
    IronTolerance
    >
    {

        protected override void DoSetUp()
        {
            Sut = new AnalyseIronQueryHandler(LevelQueryHandlerMagicStrings, GetAllOrganismsDataQueryHandler);
        }
    }
}

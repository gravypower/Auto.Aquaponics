using System;
using System.Collections.Generic;
using Ponics.Analysis.Levels.Handlers;
using Ponics.Kernel.Queries;
using Ponics.Organisms;
using Ponics.Organisms.Queries;
using Ponics.Organisms.Tolerances;

namespace Ponics.Analysis.Levels.Iron
{
    public class AnalyseIronQueryHandler: AnalyseLevelsQueryHandler<AnalyseToleranceIron, IronLevelAnalysis, IronTolerance>
    {
        private readonly IAnalyseIronMagicStrings _magicStrings;

        public AnalyseIronQueryHandler(
            IAnalyseIronMagicStrings magicStrings,
            IDataQueryHandler<GetOrganisms, List<Organism>> getAllOrganismsDataQueryHandler
        ) : base(magicStrings, getAllOrganismsDataQueryHandler)
        {
            _magicStrings = magicStrings;
        }

        protected override IronLevelAnalysis Analyse(AnalyseToleranceIron query, IronLevelAnalysis levelAnalysis, Organism organism)
        {
            return levelAnalysis;
        }

        protected override void OrganismToleranceNotDefined()
        {
            throw new NotImplementedException();
        }
    }
}

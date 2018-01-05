using System;
using System.Collections.Generic;
using Ponics.Analysis.Levels.Handlers;
using Ponics.Kernel.Queries;
using Ponics.Organisms;
using Ponics.Organisms.Tolerances;

namespace Ponics.Analysis.Levels.Salinity
{
    public class AnalyseSalinityQueryHandler: AnalyseLevelsQueryHandler<AnalyseToleranceSalinity, SalinityLevelAnalysis, SalinityTolerance>
    {
        private readonly IAnalyseSalinityMagicStrings _magicStrings;

        public AnalyseSalinityQueryHandler(
            IAnalyseSalinityMagicStrings magicStrings,
            IDataQueryHandler<GetOrganisms, List<Organism>> getAllOrganismsDataQueryHandler
            ) : base(magicStrings, getAllOrganismsDataQueryHandler)
        {
            _magicStrings = magicStrings;
        }

        protected override SalinityLevelAnalysis Analyse(AnalyseToleranceSalinity query, SalinityLevelAnalysis levelAnalysis, Organism organism)
        {
            return levelAnalysis;
        }

        protected override void OrganismToleranceNotDefined()
        {
            throw new NotImplementedException();
        }
    }
}

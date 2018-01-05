using System;
using System.Collections.Generic;
using Ponics.Analysis.Levels.Handlers;
using Ponics.Kernel.Queries;
using Ponics.Organisms;
using Ponics.Organisms.Tolerances;

namespace Ponics.Analysis.Levels.Nitrite
{
    public class AnalyseNitriteQueryHandler : AnalyseLevelsQueryHandler<AnalyseToleranceNitrite, NitriteLevelAnalysis, NitriteTolerance>
    {
        private readonly IAnalyseNitriteMagicStrings _magicStrings;

        public AnalyseNitriteQueryHandler(
            IAnalyseNitriteMagicStrings magicStrings,
            IDataQueryHandler<GetOrganisms, List<Organism>> getAllOrganismsDataQueryHandler
        ) : base(magicStrings, getAllOrganismsDataQueryHandler)
        {
            _magicStrings = magicStrings;
        }

        protected override NitriteLevelAnalysis Analyse(AnalyseToleranceNitrite query, NitriteLevelAnalysis levelAnalysis, Organism organism)
        {
            return levelAnalysis;
        }

        protected override void OrganismToleranceNotDefined()
        {
            throw new NotImplementedException();
        }
    }
}

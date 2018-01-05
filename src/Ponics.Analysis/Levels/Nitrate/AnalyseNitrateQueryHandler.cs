using System;
using System.Collections.Generic;
using Ponics.Analysis.Levels.Handlers;
using Ponics.Kernel.Queries;
using Ponics.Organisms;
using Ponics.Organisms.Tolerances;

namespace Ponics.Analysis.Levels.Nitrate
{
    public class AnalyseNitrateQueryHandler: AnalyseLevelsQueryHandler<AnalyseToleranceNitrate, NitrateLevelAnalysis, NitrateTolerance>
    {
        private readonly IAnalyseNitrateMagicStrings _magicStrings;

        public AnalyseNitrateQueryHandler(
            IAnalyseNitrateMagicStrings magicStrings,
            IDataQueryHandler<GetOrganisms, List<Organism>> getAllOrganismsDataQueryHandler
        ) : base(magicStrings, getAllOrganismsDataQueryHandler)
        {
            _magicStrings = magicStrings;
        }

        protected override NitrateLevelAnalysis Analyse(AnalyseToleranceNitrate query, NitrateLevelAnalysis levelAnalysis, Organism organism)
        {
            return levelAnalysis;
        }

        protected override void OrganismToleranceNotDefined()
        {
            throw new NotImplementedException();
        }
    }
}

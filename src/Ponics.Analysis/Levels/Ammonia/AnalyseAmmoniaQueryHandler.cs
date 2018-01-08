using System;
using System.Collections.Generic;
using Ponics.Analysis.Levels.Handlers;
using Ponics.Kernel.Queries;
using Ponics.Organisms;
using Ponics.Organisms.Queries;
using Ponics.Organisms.Tolerances;

namespace Ponics.Analysis.Levels.Ammonia
{
    public class AnalyseAmmoniaQueryHandler: AnalyseLevelsQueryHandler<AnalyseToleranceAmmonia, AmmoniaLevelAnalysis, AmmoniaTolerance>
    {
        private readonly IAnalyseAmmoniaMagicStrings _magicStrings;

        public AnalyseAmmoniaQueryHandler(
            IAnalyseAmmoniaMagicStrings magicStrings,
            IDataQueryHandler<GetOrganisms, List<Organism>> getAllOrganismsDataQueryHandler
        ) : base(magicStrings, getAllOrganismsDataQueryHandler)
        {
            _magicStrings = magicStrings; 
        }

        protected override AmmoniaLevelAnalysis Analyse(AnalyseToleranceAmmonia query, AmmoniaLevelAnalysis levelAnalysis, Organism organism)
        {
            return levelAnalysis;
        }

        protected override void OrganismToleranceNotDefined()
        {
            throw new NotImplementedException();
        }
    }
}

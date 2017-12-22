using System.Collections.Generic;
using Ponics.Analysis.Levels.Handlers;
using Ponics.Kernel.Data;
using Ponics.Organisms;

namespace Ponics.Analysis.Levels.Ammonia
{
    public class AnalyseAmmoniaQueryHandler: AnalyseLevelsQueryHandler<AnalyseToleranceAmmonia, AmmoniaToleranceAnalysis, AmmoniaTolerance>
    {
        private readonly IAnalyseAmmoniaMagicStrings _magicStrings;

        public AnalyseAmmoniaQueryHandler(
            IAnalyseAmmoniaMagicStrings magicStrings,
            IDataQueryHandler<GetOrganisms, List<Organism>> getAllOrganismsDataQueryHandler
        ) : base(magicStrings, getAllOrganismsDataQueryHandler)
        {
            _magicStrings = magicStrings; 
        }

        protected override AmmoniaToleranceAnalysis Analyse(AnalyseToleranceAmmonia query, AmmoniaToleranceAnalysis toleranceAnalysis, Organism organism)
        {
            return toleranceAnalysis;
        }

        protected override void OrganismToleranceNotDefined()
        {
            throw new System.NotImplementedException();
        }
    }
}

using System.Collections.Generic;
using Ponics.Analysis.Levels.Handlers;
using Ponics.Kernel.Data;
using Ponics.Organisms;

namespace Ponics.Analysis.Levels.Nitrate
{
    public class AnalyseNitrateQueryHandler: AnalyseLevelsQueryHandler<AnalyseToleranceNitrate, NitrateToleranceAnalysis, NitrateTolerance>
    {
        private readonly IAnalyseNitrateMagicStrings _magicStrings;

        public AnalyseNitrateQueryHandler(
            IAnalyseNitrateMagicStrings magicStrings,
            IDataQueryHandler<GetAllOrganisms, List<Organism>> getAllOrganismsDataQueryHandler
        ) : base(magicStrings, getAllOrganismsDataQueryHandler)
        {
            _magicStrings = magicStrings;
        }

        protected override NitrateToleranceAnalysis Analyse(AnalyseToleranceNitrate query, NitrateToleranceAnalysis toleranceAnalysis, Organism organism)
        {
            return toleranceAnalysis;
        }

        protected override void OrganismToleranceNotDefined()
        {
            throw new System.NotImplementedException();
        }
    }
}

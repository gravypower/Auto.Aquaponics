using System.Collections.Generic;
using Ponics.Kernel.Data;
using Ponics.Organisms;

namespace Ponics.Analysis.Levels.Nitrate
{
    public class AnalyseNitrateQueryHandler: AnalyseLevelsQueryHandler<AnalyseNitrate, NitrateAnalysis, NitrateTolerance>
    {
        private readonly IAnalyseNitrateMagicStrings _magicStrings;

        public AnalyseNitrateQueryHandler(
            IAnalyseNitrateMagicStrings magicStrings,
            IDataQueryHandler<GetAllOrganisms, List<Organism>> getAllOrganismsDataQueryHandler
        ) : base(magicStrings, getAllOrganismsDataQueryHandler)
        {
            _magicStrings = magicStrings;
        }

        protected override NitrateAnalysis Analyse(AnalyseNitrate query, NitrateAnalysis analysis, Organism organism)
        {
            return analysis;
        }

        protected override void OrganismToleranceNotDefined()
        {
            throw new System.NotImplementedException();
        }
    }
}

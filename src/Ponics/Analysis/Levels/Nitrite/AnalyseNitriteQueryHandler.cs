using System;
using System.Collections.Generic;
using Ponics.Analysis.Levels.Handlers;
using Ponics.Kernel.Data;
using Ponics.Organisms;

namespace Ponics.Analysis.Levels.Nitrite
{
    public class AnalyseNitriteQueryHandler : AnalyseLevelsQueryHandler<AnalyseToleranceNitrite, NitriteToleranceAnalysis, NitriteTolerance>
    {
        private readonly IAnalyseNitriteMagicStrings _magicStrings;

        public AnalyseNitriteQueryHandler(
            IAnalyseNitriteMagicStrings magicStrings,
            IDataQueryHandler<GetOrganisms, List<Organism>> getAllOrganismsDataQueryHandler
        ) : base(magicStrings, getAllOrganismsDataQueryHandler)
        {
            _magicStrings = magicStrings;
        }

        protected override NitriteToleranceAnalysis Analyse(AnalyseToleranceNitrite query, NitriteToleranceAnalysis toleranceAnalysis, Organism organism)
        {
            return toleranceAnalysis;
        }

        protected override void OrganismToleranceNotDefined()
        {
            throw new NotImplementedException();
        }
    }
}

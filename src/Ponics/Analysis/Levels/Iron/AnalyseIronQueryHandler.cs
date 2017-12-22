using System.Collections.Generic;
using Ponics.Analysis.Levels.Handlers;
using Ponics.Kernel.Data;
using Ponics.Organisms;

namespace Ponics.Analysis.Levels.Iron
{
    public class AnalyseIronQueryHandler: AnalyseLevelsQueryHandler<AnalyseToleranceIron, IronToleranceAnalysis, IronTolerance>
    {
        private readonly IAnalyseIronMagicStrings _magicStrings;

        public AnalyseIronQueryHandler(
            IAnalyseIronMagicStrings magicStrings,
            IDataQueryHandler<GetOrganisms, List<Organism>> getAllOrganismsDataQueryHandler
        ) : base(magicStrings, getAllOrganismsDataQueryHandler)
        {
            _magicStrings = magicStrings;
        }

        protected override IronToleranceAnalysis Analyse(AnalyseToleranceIron query, IronToleranceAnalysis toleranceAnalysis, Organism organism)
        {
            return toleranceAnalysis;
        }

        protected override void OrganismToleranceNotDefined()
        {
            throw new System.NotImplementedException();
        }
    }
}

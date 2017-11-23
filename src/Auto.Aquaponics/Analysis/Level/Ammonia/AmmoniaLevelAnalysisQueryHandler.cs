using Auto.Aquaponics.Organisms;
using System.Collections.Generic;
using Auto.Aquaponics.Kernel.DataQuery;

namespace Auto.Aquaponics.Analysis.Level.Ammonia
{
    public class AmmoniaLevelAnalysisQueryHandler: LevelAnalysisQueryHandler<AmmoniaLevelAnalysisQuery, AmmoniaLevelAnalysis>
    {
        private readonly IAmmoniaLevelAnalysisMagicStrings _magicStrings;

        public AmmoniaLevelAnalysisQueryHandler(
            IAmmoniaLevelAnalysisMagicStrings magicStrings,
            IDataQueryHandler<GetAllOrganisms, IList<Organism>> getAllOrganismsDataQueryHandler
        ) : base(magicStrings, getAllOrganismsDataQueryHandler)
        {
            _magicStrings = magicStrings;
        }

        protected override AmmoniaLevelAnalysis Analyse(AmmoniaLevelAnalysisQuery query, AmmoniaLevelAnalysis analysis, Organism organism)
        {
            return analysis;
        }
    }
}

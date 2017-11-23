using Auto.Aquaponics.Organisms;
using System.Collections.Generic;
using Auto.Aquaponics.Kernel.DataQuery;

namespace Auto.Aquaponics.Analysis.Level.Nitrate
{
    public class NitrateLevelAnalysisQueryHandler: LevelAnalysisQueryHandler<NitrateLevelAnalysisQuery, NitrateLevelAnalysis>
    {
        private readonly INitrateLevelAnalysisMagicStrings _magicStrings;

        public NitrateLevelAnalysisQueryHandler(
            INitrateLevelAnalysisMagicStrings magicStrings,
            IDataQueryHandler<GetAllOrganisms, IList<Organism>> getAllOrganismsDataQueryHandler
        ) : base(magicStrings, getAllOrganismsDataQueryHandler)
        {
            _magicStrings = magicStrings;
        }

        protected override NitrateLevelAnalysis Analyse(NitrateLevelAnalysisQuery query, NitrateLevelAnalysis analysis, Organism organism)
        {
            return analysis;
        }

    }
}

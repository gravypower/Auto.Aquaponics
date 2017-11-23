using Auto.Aquaponics.Organisms;
using System.Collections.Generic;
using Auto.Aquaponics.Kernel.DataQuery;

namespace Auto.Aquaponics.Analysis.Level.Nitrite
{
    public class NitriteLevelAnalysisQueryHandler : LevelAnalysisQueryHandler<NitriteLevelAnalysisQuery, NitriteLevelAnalysis>
    {
        private readonly INitriteLevelAnalysisMagicStrings _magicStrings;

        public NitriteLevelAnalysisQueryHandler(
            INitriteLevelAnalysisMagicStrings magicStrings,
            IDataQueryHandler<GetAllOrganisms, IList<Organism>> getAllOrganismsDataQueryHandler
        ) : base(magicStrings, getAllOrganismsDataQueryHandler)
        {
            _magicStrings = magicStrings;
        }

        protected override NitriteLevelAnalysis Analyse(NitriteLevelAnalysisQuery query, NitriteLevelAnalysis analysis, Organism organism)
        {
            return analysis;
        }
    }
}

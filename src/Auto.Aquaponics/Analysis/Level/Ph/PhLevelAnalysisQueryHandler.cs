using System;
using Auto.Aquaponics.Organisms;
using System.Collections.Generic;
using Auto.Aquaponics.Kernel.DataQuery;

namespace Auto.Aquaponics.Analysis.Level.Ph
{
    public class PhLevelAnalysisQueryHandler: LevelAnalysisQueryHandler<PhLevelAnalysisQuery, PhLevelAnalysis>
    {
        private readonly IPhLevelAnalysisMagicStrings _magicStrings;

        public PhLevelAnalysisQueryHandler(
            IPhLevelAnalysisMagicStrings magicStrings,
            IDataQueryHandler<GetAllOrganisms, IList<Organism>> getAllOrganismsDataQueryHandler
        ) : base(magicStrings, getAllOrganismsDataQueryHandler)
        {
            _magicStrings = magicStrings;
        }

        protected override PhLevelAnalysis Analyse(PhLevelAnalysisQuery query, PhLevelAnalysis analysis, Organism organism)
        {
            GuardPhValue(query);
            
            if (!organism.Tolerances.ContainsKey(_magicStrings.LevelKey))
            {
                throw new ArgumentNullException(nameof(organism.Tolerances), _magicStrings.OrganismPhTolerancesNotDefinedExceptionMessage);
            }

            analysis.HydrogenIonConcentration = HydrogenIonConcentration(query);
            analysis.HydroxideIonsConcentration = HydroxideIonsConcentration(query);

            return analysis;
        }

        private void GuardPhValue(PhLevelAnalysisQuery query)
        {
            if (query.Value < PhRange.Floor)
            {
                throw new ArgumentOutOfRangeException(nameof(query.Value),
                    _magicStrings.LowPhArgumentOutOfRangeExceptionMessage);
            }

            if (query.Value > PhRange.Ceiling)
            {
                throw new ArgumentOutOfRangeException(nameof(query.Value),
                    _magicStrings.HightPhArgumentOutOfRangeExceptionMessage);
            }
        }

        private static double HydroxideIonsConcentration(PhLevelAnalysisQuery query)
        {
            //pOH = 14 - pH
            //[OH-] 10 ^ -pOH
            var hydroxideIonsConcentration = Math.Pow(10, -(14 - query.Value));
            return hydroxideIonsConcentration;
        }

        private static double HydrogenIonConcentration(PhLevelAnalysisQuery query)
        {
            //[H+] = 10 ^ -pH
            var hydrogenIonConcentration = Math.Pow(10, -query.Value);
            return hydrogenIonConcentration;
        }
    }
}

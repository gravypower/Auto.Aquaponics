using System;
using System.Linq;
using Auto.Aquaponics.Ph;
using Auto.Aquaponics.Organisms;
using System.Collections.Generic;

namespace Auto.Aquaponics.Analysis.Level.Ph
{
    public class PhLevelAnalysisQueryHandler: LevelAnalysisQueryHandler<PhLevelAnalysisQuery, PhLevelAnalysis>
    {
        private readonly IPhLevelAnalysisMagicStrings _magicStrings;
        private readonly IPhRange _phRange;

        public PhLevelAnalysisQueryHandler(
            IPhLevelAnalysisMagicStrings magicStrings,
            IPhRange phRange,
            IEnumerable<Organism> organisms
            ) : base(magicStrings, organisms)
        {
            _magicStrings = magicStrings;
            _phRange = phRange;
        }

        protected override PhLevelAnalysis Analyse(PhLevelAnalysisQuery query, PhLevelAnalysis analysis)
        {
            GuardPhValue(query);
            
            var organism = Organisms.SingleOrDefault(o => o.Id == query.OrganismId);

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
            if (query.Value < _phRange.Floor)
            {
                throw new ArgumentOutOfRangeException(nameof(query.Value),
                    _magicStrings.LowPhArgumentOutOfRangeExceptionMessage);
            }

            if (query.Value > _phRange.Ceiling)
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

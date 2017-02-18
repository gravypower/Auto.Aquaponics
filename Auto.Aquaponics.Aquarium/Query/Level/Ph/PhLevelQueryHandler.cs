using System;
using Auto.Aquaponics.Aquarium.Ph;

namespace Auto.Aquaponics.Aquarium.Query.Level.Ph
{
    public class PhLevelQueryHandler: LevelQueryHandler<PhLevel, PhLevelAnalysis>
    {
        private readonly IPhLevelQueryHandlerMagicStrings _phLevelQueryHandlerMagicStrings;
        private readonly IPhRange _phRange;

        public PhLevelQueryHandler(
            IPhLevelQueryHandlerMagicStrings phLevelQueryHandlerMagicStrings,
            IPhRange phRange
            ) : base(phLevelQueryHandlerMagicStrings)
        {
            _phLevelQueryHandlerMagicStrings = phLevelQueryHandlerMagicStrings;
            _phRange = phRange;
        }

        protected override PhLevelAnalysis Analyse(PhLevel query, PhLevelAnalysis analysis)
        {
            GuardPhValue(query);

            if (!query.Organism.Tolerances.ContainsKey(_phLevelQueryHandlerMagicStrings.LevelKey))
            {
                throw new ArgumentNullException(nameof(query.Organism.Tolerances), _phLevelQueryHandlerMagicStrings.OrganismPhTolerancesNotDefinedExceptionMessage);
            }

            analysis.HydrogenIonConcentration = HydrogenIonConcentration(query);
            analysis.HydroxideIonsConcentration = HydroxideIonsConcentration(query);

            return analysis;
        }

        private void GuardPhValue(PhLevel query)
        {
            if (query.Vaue < _phRange.Floor)
            {
                throw new ArgumentOutOfRangeException(nameof(query.Vaue),
                    _phLevelQueryHandlerMagicStrings.LowPhArgumentOutOfRangeExceptionMessage);
            }

            if (query.Vaue > _phRange.Ceiling)
            {
                throw new ArgumentOutOfRangeException(nameof(query.Vaue),
                    _phLevelQueryHandlerMagicStrings.HightPhArgumentOutOfRangeExceptionMessage);
            }
        }

        private static double HydroxideIonsConcentration(PhLevel query)
        {
            //pOH = 14 - pH
            //[OH-] 10 ^ -pOH
            var hydroxideIonsConcentration = Math.Pow(10, -(14 - query.Vaue));
            return hydroxideIonsConcentration;
        }

        private static double HydrogenIonConcentration(PhLevel query)
        {
            //[H+] = 10 ^ -pH
            var hydrogenIonConcentration = Math.Pow(10, -query.Vaue);
            return hydrogenIonConcentration;
        }
    }
}

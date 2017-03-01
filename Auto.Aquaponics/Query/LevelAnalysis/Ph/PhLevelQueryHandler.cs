using System;
using Auto.Aquaponics.Ph;

namespace Auto.Aquaponics.Query.LevelAnalysis.Ph
{
    public class PhLevelQueryHandler: LevelQueryHandler<PhLevelAnalysis, PhLevelAnalysisResult>
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

        protected override PhLevelAnalysisResult Analyse(PhLevelAnalysis query, PhLevelAnalysisResult analysisResult)
        {
            GuardPhValue(query);

            if (!query.Organism.Tolerances.ContainsKey(_phLevelQueryHandlerMagicStrings.LevelKey))
            {
                throw new ArgumentNullException(nameof(query.Organism.Tolerances), _phLevelQueryHandlerMagicStrings.OrganismPhTolerancesNotDefinedExceptionMessage);
            }

            analysisResult.HydrogenIonConcentration = HydrogenIonConcentration(query);
            analysisResult.HydroxideIonsConcentration = HydroxideIonsConcentration(query);

            return analysisResult;
        }

        private void GuardPhValue(PhLevelAnalysis query)
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

        private static double HydroxideIonsConcentration(PhLevelAnalysis query)
        {
            //pOH = 14 - pH
            //[OH-] 10 ^ -pOH
            var hydroxideIonsConcentration = Math.Pow(10, -(14 - query.Vaue));
            return hydroxideIonsConcentration;
        }

        private static double HydrogenIonConcentration(PhLevelAnalysis query)
        {
            //[H+] = 10 ^ -pH
            var hydrogenIonConcentration = Math.Pow(10, -query.Vaue);
            return hydrogenIonConcentration;
        }
    }
}

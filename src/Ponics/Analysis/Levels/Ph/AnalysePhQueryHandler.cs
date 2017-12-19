using System;
using System.Collections.Generic;
using Ponics.Analysis.Levels.Handlers;
using Ponics.Kernel.Data;
using Ponics.Organisms;

namespace Ponics.Analysis.Levels.Ph
{
    public class AnalysePhQueryHandler: AnalyseLevelsQueryHandler<AnalyseTolerancePh, PhToleranceAnalysis, PhTolerance>
    {
        private readonly IAnalysePhMagicStrings _magicStrings;

        public AnalysePhQueryHandler(
            IAnalysePhMagicStrings magicStrings,
            IDataQueryHandler<GetAllOrganisms, List<Organism>> getAllOrganismsDataQueryHandler
        ) : base(magicStrings, getAllOrganismsDataQueryHandler)
        {
            _magicStrings = magicStrings;
        }

        protected override PhToleranceAnalysis Analyse(AnalyseTolerancePh query, PhToleranceAnalysis toleranceAnalysis, Organism organism)
        {
            GuardPhValue(query);
            toleranceAnalysis.HydrogenIonConcentration = HydrogenIonConcentration(query);
            toleranceAnalysis.HydroxideIonsConcentration = HydroxideIonsConcentration(query);

            return toleranceAnalysis;
        }

        protected override void OrganismToleranceNotDefined()
        {
            throw new ArgumentNullException(nameof(Organism.Tolerances), _magicStrings.OrganismPhTolerancesNotDefinedExceptionMessage);
        }

        private void GuardPhValue(AnalyseTolerancePh query)
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

        private static double HydroxideIonsConcentration(AnalyseTolerancePh query)
        {
            //pOH = 14 - pH
            //[OH-] 10 ^ -pOH
            var hydroxideIonsConcentration = Math.Pow(10, -(14 - query.Value));
            return hydroxideIonsConcentration;
        }

        private static double HydrogenIonConcentration(AnalyseTolerancePh query)
        {
            //[H+] = 10 ^ -pH
            var hydrogenIonConcentration = Math.Pow(10, -query.Value);
            return hydrogenIonConcentration;
        }
    }
}

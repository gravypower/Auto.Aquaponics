using System;
using System.Collections.Generic;
using Ponics.Kernel.Data;
using Ponics.Organisms;

namespace Ponics.Analysis.Levels.Ph
{
    public class AnalysePhQueryHandler: AnalyseLevelsQueryHandler<AnalysePh, PhAnalysis, PhTolerance>
    {
        private readonly IAnalysePhMagicStrings _magicStrings;

        public AnalysePhQueryHandler(
            IAnalysePhMagicStrings magicStrings,
            IDataQueryHandler<GetAllOrganisms, IList<Organism>> getAllOrganismsDataQueryHandler
        ) : base(magicStrings, getAllOrganismsDataQueryHandler)
        {
            _magicStrings = magicStrings;
        }

        protected override PhAnalysis Analyse(AnalysePh query, PhAnalysis analysis, Organism organism)
        {
            GuardPhValue(query);
            analysis.HydrogenIonConcentration = HydrogenIonConcentration(query);
            analysis.HydroxideIonsConcentration = HydroxideIonsConcentration(query);

            return analysis;
        }

        protected override void OrganismToleranceNotDefined()
        {
            throw new ArgumentNullException(nameof(Organism.Tolerances), _magicStrings.OrganismPhTolerancesNotDefinedExceptionMessage);
        }

        private void GuardPhValue(AnalysePh query)
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

        private static double HydroxideIonsConcentration(AnalysePh query)
        {
            //pOH = 14 - pH
            //[OH-] 10 ^ -pOH
            var hydroxideIonsConcentration = Math.Pow(10, -(14 - query.Value));
            return hydroxideIonsConcentration;
        }

        private static double HydrogenIonConcentration(AnalysePh query)
        {
            //[H+] = 10 ^ -pH
            var hydrogenIonConcentration = Math.Pow(10, -query.Value);
            return hydrogenIonConcentration;
        }
    }
}

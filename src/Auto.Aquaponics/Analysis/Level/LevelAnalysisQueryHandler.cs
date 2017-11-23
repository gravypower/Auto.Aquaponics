using System;
using System.Linq;
using Auto.Aquaponics.Query;
using Auto.Aquaponics.Organisms;
using System.Collections.Generic;

namespace Auto.Aquaponics.Analysis.Level
{
    public abstract class LevelAnalysisQueryHandler<TQuery, TResult> : IQueryHandler<TQuery, TResult>
        where TQuery: LevelAnalysisQuery<TResult>
        where TResult:LevelAnalysis, new()
    {
        protected readonly ILevelMagicStrings MagicStrings;
        protected IEnumerable<Organism> Organisms { get; }

        protected LevelAnalysisQueryHandler(
            ILevelMagicStrings magicStrings,
            IEnumerable<Organism> organisms
            )
        {
            MagicStrings = magicStrings;
            Organisms = organisms;
        }

        protected abstract TResult Analyse(TQuery query, TResult analysis);

        public TResult Handle(TQuery query)
        {
            var organism = Organisms.SingleOrDefault(o => o.Id == query.OrganismId);
            if (organism == default(Organism))
            {
                throw new ArgumentNullException(nameof(organism), MagicStrings.OrganismNotDefined);
            }

            if (organism.Tolerances == null || !organism.Tolerances.Any())
            {
                throw new ArgumentNullException(nameof(organism.Tolerances), MagicStrings.OrganismTolerancesNotDefined);
            }

            var analysis = new TResult
            {
                IdealForOrganism = IdealForOrganism(query.Value, organism, MagicStrings.LevelKey),
                SutablalForOrganism = SutablalForOrganism(query.Value, organism, MagicStrings.LevelKey)
            };

            return Analyse(query, analysis);
        }

        protected bool? SutablalForOrganism(double value, Organism organism, string key)
        {
            if (organism.Tolerances.ContainsKey(key))
            {
                return
                    organism.Tolerances[key].Lower <= value &&
                    organism.Tolerances[key].Upper >= value;
            }

            return null;
        }

        protected bool? IdealForOrganism(double value, Organism organism, string key)
        {
            if (organism.Tolerances.ContainsKey(key))
            {
                return
                    organism.Tolerances[key].DesiredLower <= value &&
                    organism.Tolerances[key].DesiredUpper >= value;
            }

            return null;

        }
    }
}

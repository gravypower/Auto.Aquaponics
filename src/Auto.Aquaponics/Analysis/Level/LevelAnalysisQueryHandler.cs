using System;
using System.Linq;
using Auto.Aquaponics.Kernel.Query;

namespace Auto.Aquaponics.Analysis.Level
{
    public abstract class LevelAnalysisQueryHandler<TQuery, TResult> : IQueryHandler<TQuery, TResult>
        where TQuery: LevelAnalysisQuery<TResult>
        where TResult:LevelAnalysis, new()
    {
        protected readonly ILevelMagicStrings MagicStrings;

        protected LevelAnalysisQueryHandler(ILevelMagicStrings magicStrings)
        {
            MagicStrings = magicStrings;
        }

        protected abstract TResult Analyse(TQuery query, TResult analysis);

        public TResult Handle(TQuery query)
        {
            if (query.Organism == null)
            {
                throw new ArgumentNullException(nameof(query.Organism), MagicStrings.OrganismNotDefined);
            }

            if (query.Organism.Tolerances == null || !query.Organism.Tolerances.Any())
            {
                throw new ArgumentNullException(nameof(query.Organism.Tolerances), MagicStrings.OrganismTolerancesNotDefined);
            }

            var analysis = new TResult
            {
                IdealForOrganism = IdealForOrganism(query, MagicStrings.LevelKey),
                SutablalForOrganism = SutablalForOrganism(query, MagicStrings.LevelKey)
            };

            return Analyse(query, analysis);
        }

        protected bool? SutablalForOrganism(TQuery analysisQuery, string key)
        {
            if (analysisQuery.Organism.Tolerances.ContainsKey(key))
            {
                return
                    analysisQuery.Organism.Tolerances[key].Lower <= analysisQuery.Value &&
                    analysisQuery.Organism.Tolerances[key].Upper >= analysisQuery.Value;
            }

            return null;
        }

        protected bool? IdealForOrganism(TQuery analysisQuery, string key)
        {
            if (analysisQuery.Organism.Tolerances.ContainsKey(key))
            {
                return
                    analysisQuery.Organism.Tolerances[key].DesiredLower <= analysisQuery.Value &&
                    analysisQuery.Organism.Tolerances[key].DesiredUpper >= analysisQuery.Value;
            }

            return null;

        }
    }
}

using System;
using System.Linq;
using Auto.Aquaponics.Query;
using Auto.Aquaponics.Organisms;
using System.Collections.Generic;
using Auto.Aquaponics.Kernel.DataQuery;

namespace Auto.Aquaponics.Analysis.Level
{
    public abstract class LevelAnalysisQueryHandler<TQuery, TResult> : IQueryHandler<TQuery, TResult>
        where TQuery: LevelAnalysisQuery<TResult>
        where TResult:LevelAnalysis, new()
    {
        protected readonly ILevelMagicStrings MagicStrings;
        private readonly IDataQueryHandler<GetAllOrganisms, IList<Organism>> _getAllOrganismsDataQueryHandler;

        protected LevelAnalysisQueryHandler(
            ILevelMagicStrings magicStrings,
            IDataQueryHandler<GetAllOrganisms, IList<Organism>> getAllOrganismsDataQueryHandler
            )
        {
            MagicStrings = magicStrings;
            _getAllOrganismsDataQueryHandler = getAllOrganismsDataQueryHandler;
        }

        protected abstract TResult Analyse(TQuery query, TResult analysis, Organism organism);

        public TResult Handle(TQuery query)
        {
            var organisms = _getAllOrganismsDataQueryHandler.Handle(new GetAllOrganisms());
            var organism = organisms.SingleOrDefault(o => o.Id == query.OrganismId);
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

            return Analyse(query, analysis, organism);
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

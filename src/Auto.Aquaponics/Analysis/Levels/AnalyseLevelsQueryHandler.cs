using System;
using System.Linq;
using Auto.Aquaponics.Query;
using Auto.Aquaponics.Organisms;
using System.Collections.Generic;
using Auto.Aquaponics.Kernel.DataQuery;

namespace Auto.Aquaponics.Analysis.Levels
{
    public abstract class AnalyseLevelsQueryHandler<TQuery, TResult> : IQueryHandler<TQuery, TResult>
        where TQuery: AnalyseQuery<TResult>
        where TResult:Analysis, new()
    {
        protected readonly ILevelMagicStrings MagicStrings;
        private readonly IDataQueryHandler<GetAllOrganisms, IList<Organism>> _getAllOrganismsDataQueryHandler;

        protected AnalyseLevelsQueryHandler(
            ILevelMagicStrings magicStrings,
            IDataQueryHandler<GetAllOrganisms, IList<Organism>> getAllOrganismsDataQueryHandler
            )
        {
            MagicStrings = magicStrings;
            _getAllOrganismsDataQueryHandler = getAllOrganismsDataQueryHandler;
        }

        protected abstract TResult Analyse(TQuery query, TResult analysis, Organism organism);
        protected abstract void OrganismToleranceNotDefined();

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

            if (!organism.Tolerances.ContainsKey(MagicStrings.LevelKey))
            {
                OrganismToleranceNotDefined();
            }

            var analysis = new TResult
            {
                IdealForOrganism = IdealForOrganism(query.Value, organism, MagicStrings.LevelKey),
                SutablalForOrganism = SutablalForOrganism(query.Value, organism, MagicStrings.LevelKey),
                Tolerance = organism.Tolerances[MagicStrings.LevelKey]
            };

           

            return Analyse(query, analysis, organism);
        }

        protected bool SutablalForOrganism(double value, Organism organism, string key)
        {
            return
                organism.Tolerances[key].Lower <= value &&
                organism.Tolerances[key].Upper >= value;

        }

        protected bool IdealForOrganism(double value, Organism organism, string key)
        {
            return
                organism.Tolerances[key].DesiredLower <= value &&
                organism.Tolerances[key].DesiredUpper >= value;

        }
    }
}

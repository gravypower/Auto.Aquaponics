using System;
using System.Linq;
using Auto.Aquaponics.Organisms;
using System.Collections.Generic;
using Auto.Aquaponics.Kernel.Data;
using Auto.Aquaponics.Queries;

namespace Auto.Aquaponics.Analysis.Levels
{
    public abstract class AnalyseLevelsQueryHandler<TQuery, TResult, TTolerance> : IQueryHandler<TQuery, TResult>
        where TQuery: AnalyseQuery<TResult, TTolerance>
        where TResult:Analysis<TTolerance>, new()
        where TTolerance : Tolerance
    {
        protected readonly ILevelsMagicStrings MagicStrings;
        private readonly IDataQueryHandler<GetAllOrganisms, IList<Organism>> _getAllOrganismsDataQueryHandler;

        protected AnalyseLevelsQueryHandler(
            ILevelsMagicStrings magicStrings,
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

            if (!organism.Tolerances.Any(t =>t is TTolerance))
            {
                OrganismToleranceNotDefined();
            }


            var analysis = new TResult
            {
                IdealForOrganism = IdealForOrganism(query.Value, organism, MagicStrings.LevelsKey),
                SutablalForOrganism = SutablalForOrganism(query.Value, organism, MagicStrings.LevelsKey),
                Tolerance = organism.Tolerances.Single(t => t is TTolerance) as TTolerance
            };

            return Analyse(query, analysis, organism);
        }

        protected bool SutablalForOrganism(double value, Organism organism, string key)
        {
            var tolerance = organism.Tolerances.Single(t => t is TTolerance);

            return tolerance.Lower <= value && tolerance.Upper >= value;
        }

        protected bool IdealForOrganism(double value, Organism organism, string key)
        {

            var tolerance = organism.Tolerances.Single(t => t is TTolerance);

            return tolerance.DesiredLower <= value && tolerance.DesiredUpper >= value;
        }
    }
}
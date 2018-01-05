using System;
using System.Collections.Generic;
using System.Linq;
using Ponics.Analysis.Levels.MagicStrings;
using Ponics.Kernel.Queries;
using Ponics.Organisms;

namespace Ponics.Analysis.Levels.Handlers
{
    public abstract class AnalyseLevelsQueryHandler<TQuery, TResult, TTolerance> : IAnalyseLevelsQueryHandler, IQueryHandler<TQuery, TResult>
        where TQuery : AnalyseToleranceQuery<TResult, TTolerance>
        where TResult : LevelAnalysis<TTolerance>, new()
        where TTolerance : Tolerance
    {
        public string AnalyserFor => MagicStrings.LevelName;
        public Type QueryType => typeof(TQuery);

        protected readonly ILevelsMagicStrings MagicStrings;
        private readonly IDataQueryHandler<GetOrganisms, List<Organism>> _getAllOrganismsDataQueryHandler;

        protected AnalyseLevelsQueryHandler(
            ILevelsMagicStrings magicStrings,
            IDataQueryHandler<GetOrganisms, List<Organism>> getAllOrganismsDataQueryHandler
        )
        {
            MagicStrings = magicStrings;
            _getAllOrganismsDataQueryHandler = getAllOrganismsDataQueryHandler;
        }

        protected abstract TResult Analyse(TQuery query, TResult analysis, Organism organism);
        protected abstract void OrganismToleranceNotDefined();

        LevelAnalysis IAnalyseLevelsQueryHandler.Handle(AnalyseToleranceQuery query)
        {
            return Handle(query as TQuery);
        }

        public TResult Handle(TQuery query)
        {
            var organisms = _getAllOrganismsDataQueryHandler.Handle(new GetOrganisms());
            var organism = organisms.SingleOrDefault(o => o.Id == query.OrganismId);
            if (organism == default(Organism))
            {
                throw new ArgumentNullException(nameof(organism), MagicStrings.OrganismNotDefined);
            }

            if (organism.Tolerances == null || !organism.Tolerances.Any())
            {
                throw new ArgumentNullException(nameof(organism.Tolerances), MagicStrings.OrganismTolerancesNotDefined);
            }

            if (!organism.Tolerances.Any(t => t is TTolerance))
            {
                OrganismToleranceNotDefined();
            }

            var analysis = new TResult
            {
                IdealForOrganism = IdealForOrganism(query.Value, organism, MagicStrings.LevelName),
                SuitableForOrganism = SuitableForOrganism(query.Value, organism, MagicStrings.LevelName),
                Tolerance = organism.Tolerances.Single(t => t is TTolerance) as TTolerance
            };

            return Analyse(query, analysis, organism);
        }

        protected bool SuitableForOrganism(double value, Organism organism, string key)
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

    public interface IAnalyseLevelsQueryHandler
    {
        string AnalyserFor { get; }
        Type QueryType { get; }
        LevelAnalysis Handle(AnalyseToleranceQuery query);
    }
}
using System;
using Auto.Aquaponics.Kernel.Query;

namespace Auto.Aquaponics.Aquarium.Query.Level
{
    public abstract class LevelQueryHandler<TQuery, TResult> : IQueryHandler<TQuery, TResult>
        where TQuery:LevelQuery
        where TResult:LevelAnalysis, new()
    {
        protected readonly ILevelQueryHandlerMagicStrings LevelQueryHandlerMagicStrings;

        protected LevelQueryHandler(ILevelQueryHandlerMagicStrings levelQueryHandlerMagicStrings)
        {
            LevelQueryHandlerMagicStrings = levelQueryHandlerMagicStrings;
        }

        protected abstract TResult Analyse(TQuery query, TResult analysis);

        public TResult Handle(TQuery query)
        {
            if (query.Organism == null)
            {
                throw new ArgumentNullException(nameof(query.Organism), LevelQueryHandlerMagicStrings.OrganismNotDefinedExceptionMessage);
            }

            if (query.Organism.Tolerances == null)
            {
                throw new ArgumentNullException(nameof(query.Organism.Tolerances), LevelQueryHandlerMagicStrings.OrganismTolerancesNotDefinedExceptionMessage);
            }

            var analysis = new TResult
            {
                IdealForOrganism = IdealForOrganism(query, LevelQueryHandlerMagicStrings.LevelKey),
                SutablalForOrganism = SutablalForOrganism(query, LevelQueryHandlerMagicStrings.LevelKey)
            };

            return Analyse(query, analysis);
        }


        protected bool? SutablalForOrganism(LevelQuery query, string key)
        {
            if (query.Organism.Tolerances.ContainsKey(key))
            {
                return
                    query.Organism.Tolerances[key].Lower <= query.Vaue &&
                    query.Organism.Tolerances[key].Upper >= query.Vaue;
            }

            return null;
        }

        protected bool? IdealForOrganism(LevelQuery query, string key)
        {
            if (query.Organism.Tolerances.ContainsKey(key))
            {
                return
                    query.Organism.Tolerances[key].DesiredLower <= query.Vaue &&
                    query.Organism.Tolerances[key].DesiredUpper >= query.Vaue;
            }

            return null;

        }
    }
}

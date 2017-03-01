using System;
using Auto.Aquaponics.Kernel.Query;

namespace Auto.Aquaponics.Query.LevelAnalysis
{
    public abstract class LevelQueryHandler<TQuery, TResult> : IQueryHandler<TQuery, TResult>
        where TQuery:LevelAnalysisQuery
        where TResult:LevelAnalysisResult, new()
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


        protected bool? SutablalForOrganism(LevelAnalysisQuery analysisQuery, string key)
        {
            if (analysisQuery.Organism.Tolerances.ContainsKey(key))
            {
                return
                    analysisQuery.Organism.Tolerances[key].Lower <= analysisQuery.Vaue &&
                    analysisQuery.Organism.Tolerances[key].Upper >= analysisQuery.Vaue;
            }

            return null;
        }

        protected bool? IdealForOrganism(LevelAnalysisQuery analysisQuery, string key)
        {
            if (analysisQuery.Organism.Tolerances.ContainsKey(key))
            {
                return
                    analysisQuery.Organism.Tolerances[key].DesiredLower <= analysisQuery.Vaue &&
                    analysisQuery.Organism.Tolerances[key].DesiredUpper >= analysisQuery.Vaue;
            }

            return null;

        }
    }
}

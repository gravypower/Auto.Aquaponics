using System.Collections.Generic;
using Auto.Aquaponics.Analysis.Level;
using Auto.Aquaponics.Kernel.Query;
using Auto.Aquaponics.Organisms;

namespace Auto.Aquaponics.Analysis.System
{
    public class SystemAnalysisHandler : IQueryHandler<SystemAnalysisQuery, SystemAnalysis>
    {
        private readonly IQueryProcessor _queryProcessor;

        public SystemAnalysisHandler(IQueryProcessor queryProcessor)
        {
            _queryProcessor = queryProcessor;
        }
        public SystemAnalysis Handle(SystemAnalysisQuery query)
        {
            var result = new SystemAnalysis();
            foreach (var component in query.System.Components)
            {
                result.Results.Add(component, new Dictionary<Organism, IList<LevelAnalysis>>());
                foreach (var organism in component.Organisms)
                {
                    result.Results[component].Add(organism, new List<LevelAnalysis>());

                    var q = query.LevelAnalysisQuery.Clone();
                    q.Organism = organism;

                    var r = _queryProcessor.Process<LevelAnalysisQuery<LevelAnalysis>, LevelAnalysis>(q);
                    
                    result.Results[component][organism].Add(r);
                }
            }
            
            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using Auto.Aquaponics.Components;
using Auto.Aquaponics.Kernel.GraphTheory.Graphs;
using Auto.Aquaponics.Kernel.Query;
using Auto.Aquaponics.Organisms;
using Auto.Aquaponics.Query.LevelAnalysis;

namespace Auto.Aquaponics
{
    public class AquaponicSystem
    {
        private readonly IGraph<Component> _graph;
        private readonly IDictionary<Type, IQueryHandler<LevelAnalysisQuery, LevelAnalysisResult>> _levelAnalysisQueryHandleres;

        public AquaponicSystem(IGraph<Component> graph, IDictionary<Type, IQueryHandler<LevelAnalysisQuery, LevelAnalysisResult>> levelAnalysisQueryHandleres)
        {
            _graph = graph;
            _levelAnalysisQueryHandleres = levelAnalysisQueryHandleres;
        }

        public void AddComponents(params Component[] components)
        {
            for (var i = 0; i < components.Length; i++)
            {
                _graph.InsertVertex(components[i]);
                if (i > 0)
                {
                    _graph.InsertEdge(components[i - 1], components[i]);
                }
            }

        }

        public IDictionary<Organism, LevelAnalysisResult> RunAnalysis<TLevelAnalysisQuery>(double value)
            where TLevelAnalysisQuery: LevelAnalysisQuery
        {
            var queryType = typeof(TLevelAnalysisQuery);

            if (!_levelAnalysisQueryHandleres.ContainsKey(queryType)) return null;

            var query = Activator.CreateInstance(typeof(TLevelAnalysisQuery), null) as TLevelAnalysisQuery;

            var results = new Dictionary<Organism, LevelAnalysisResult>();
            foreach (var component in _graph.VerticesAndEdges.Keys)
            {
                foreach (var organism in component.Organisms)
                {
                    var result = _levelAnalysisQueryHandleres[queryType].Handle(query);
                    results.Add(organism, result);
                }
            }

            return results;
        }
    }
}

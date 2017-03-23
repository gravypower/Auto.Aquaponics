using System.Collections.Generic;
using Auto.Aquaponics.Components;
using Auto.Aquaponics.Kernel.GraphTheory.Graphs;

namespace Auto.Aquaponics
{
    public class AquaponicSystem
    {
        public string Name { get; }
        public ICollection<Component> Components => _graph.VerticesAndEdges.Keys;
        private readonly IGraph<Component> _graph;

        public AquaponicSystem(string name)
        {
            Name = name;
        }

        public AquaponicSystem(string name, IGraph<Component> graph):this(name)
        {
            _graph = graph;

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
    }
}

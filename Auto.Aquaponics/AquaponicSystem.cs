using Auto.Aquaponics.Components;
using Auto.Aquaponics.Kernel.GraphTheory.Graphs;

namespace Auto.Aquaponics
{
    public class AquaponicSystem
    {
        private readonly IGraph<Component> _graph;

        public AquaponicSystem(IGraph<Component> graph)
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

using System.Collections.Generic;
using Auto.Aquaponics.Components;
using Auto.Aquaponics.Kernel.GraphTheory.Graphs;

namespace Auto.Aquaponics
{
    public class AquaponicSystem
    {
        public IGraph<Component> ComponentGraph { get; }

        public IEnumerable<Component> Components => ComponentGraph.VerticesAndEdges.Keys;

        protected AquaponicSystem()
        { }

        public AquaponicSystem(IGraph<Component> componentGraph)
        {
            ComponentGraph = componentGraph;
        }

        public void AddComponents(params Component[] components)
        {
            for (var i = 0; i < components.Length; i++)
            {
                ComponentGraph.InsertVertex(components[i]);
                if (i > 0)
                {
                    ComponentGraph.InsertEdge(components[i - 1], components[i]);
                }
            }
        }
    }
}

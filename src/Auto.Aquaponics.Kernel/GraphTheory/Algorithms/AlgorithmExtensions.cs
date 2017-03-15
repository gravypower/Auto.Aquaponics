using System.Collections.Generic;
using Auto.Aquaponics.Kernel.GraphTheory.Graphs;

namespace Auto.Aquaponics.Kernel.GraphTheory.Algorithms
{
    public static class AlgorithmExtensions
    {
        public static IList<TVertex> TopologicalSort<TVertex>(this DirectedAcyclicGraph<TVertex> graph)
        {
            return new TopologicalSortAlgorithm<TVertex>(graph).SortedVertices;
        }
    }
}

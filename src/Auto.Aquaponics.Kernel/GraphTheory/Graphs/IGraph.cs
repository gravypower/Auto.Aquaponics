using System.Collections.Generic;

namespace Auto.Aquaponics.Kernel.GraphTheory.Graphs
{
    public interface IGraph<TVertex>
    {
        IDictionary<TVertex, IList<IEdge<TVertex>>> VerticesAndEdges { get; }
        void InsertVertex(TVertex vertex);
        void InsertEdge(TVertex source, TVertex target);
    }
}
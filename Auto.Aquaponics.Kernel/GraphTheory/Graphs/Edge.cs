﻿namespace Auto.Aquaponics.Kernel.GraphTheory.Graphs
{
    public class Edge<TVertex> : IEdge<TVertex>
    {
        public TVertex Source { get; set; }

        public TVertex Target { get; set; }
    }
}

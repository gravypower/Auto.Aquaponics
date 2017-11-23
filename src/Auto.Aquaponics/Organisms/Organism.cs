using System;
using System.Collections.Generic;

namespace Auto.Aquaponics.Organisms
{
    public class Organism
    {
        public string Name { get; }
        public Guid Id { get; }

        public IDictionary<string, Tolerance> Tolerances { get;  }

        protected Organism()
        {
            Tolerances = new Dictionary<string, Tolerance>();
        }

        public Organism(Guid id, string name):this()
        {
            Id = id;
            Name = name;
        }

        public void AddTolerances(Tolerance tolerance)
        {
            Tolerances[tolerance.Name] = tolerance;
        }
    }
}

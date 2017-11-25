using System;
using System.Collections.Generic;
using Auto.Aquaponics.Tolerances;

namespace Auto.Aquaponics.Organisms
{
    public class Organism
    {
        public string Name { get; }
        public Guid Id { get; }

        public IList<Tolerance> Tolerances { get;  }

        protected Organism()
        {
            Tolerances = new List<Tolerance>();
        }

        public Organism(Guid id, string name):this()
        {
            Id = id;
            Name = name;
        }

    }
}

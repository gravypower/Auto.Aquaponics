using System.Collections.Generic;

namespace Auto.Aquaponics.Organisms
{
    public class Organism
    {
        public string Name { get; }

        public IDictionary<string, Tolerance> Tolerances { get;  }

        protected Organism()
        {
            Tolerances = new Dictionary<string, Tolerance>();
        }

        public Organism(string name):this()
        {
            Name = name;
        }

        public void AddTolerances(Tolerance tolerance)
        {
            Tolerances[tolerance.Name] = tolerance;
        }
    }
}

using System.Collections.Generic;

namespace Auto.Aquaponics.Organism
{
    public abstract class Organism
    {
        public string Name { get; }

        public IDictionary<string, Tolerances> Tolerances { get;  }

        protected Organism()
        {
            Tolerances = new Dictionary<string, Tolerances>();
        }

        protected Organism(string name):this()
        {
            Name = name;
        }

        public void AddTolerances(Tolerances tolerances)
        {
            Tolerances[tolerances.Name] = tolerances;
        }
    }
}

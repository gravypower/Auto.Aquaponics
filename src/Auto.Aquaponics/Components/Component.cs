using System.Collections.Generic;
using Auto.Aquaponics.Organisms;

namespace Auto.Aquaponics.Components
{
    public class Component
    {
        public IList<Organism> Organisms { get; }

        public Component()
        {
            Organisms = new List<Organism>();
        }

        public void AddOrganisms(params Organism[] organisms)
        {
            foreach (var organism in organisms)
            {
                Organisms.Add(organism);
            }
        }
    }
}

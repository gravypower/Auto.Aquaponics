using System.Collections.Generic;
using Auto.Aquaponics.Organisms;
using System;

namespace Auto.Aquaponics.Components
{
    public class Component
    {
        public string Name { get; set; }
        
        public IList<Guid> Organisms { get; set; }

        public Component()
        {
            Organisms = new List<Guid>();
        }
        
        public void AddOrganisms(params Guid[] organisms)
        {
            foreach (var organism in organisms)
            {
                Organisms.Add(organism);
            }
        }
    }
}

using System.Collections.Generic;
using Auto.Aquaponics.Organisms;
using System;

namespace Auto.Aquaponics.Components
{
    public class Component
    {
        public string Id { get; }
        public IList<Guid> Organisms { get; }

        public Component()
        {
            Organisms = new List<Guid>();
        }
        public Component(string id):this()
        {
            Id = id;
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

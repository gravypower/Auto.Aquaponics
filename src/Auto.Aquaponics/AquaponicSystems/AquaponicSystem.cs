using System;
using System.Collections.Generic;
using System.Linq;
using Auto.Aquaponics.Components;

namespace Auto.Aquaponics.AquaponicSystems
{
    public class AquaponicSystem
    {
        public bool Closed { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Component> Components { get; set; }
        public ICollection<ComponentConnection> ComponentConnections { get; set; }

        public AquaponicSystem(bool closed = true)
        {
            Closed = closed;
            Components = new List<Component>();
            ComponentConnections = new List<ComponentConnection>();
        }

        public void AddComponents(params Component[] components)
        {
            for (var i = 0; i < components.Length; i++)
            {
                Components.Add(components[i]);
                if (i > 0)
                {
                    ComponentConnections.Add(new ComponentConnection(components[i - 1], components[i]));
                }
            }

            if (Closed)
            {
                ComponentConnections.Add(new ComponentConnection(components.Last(), components.First()));
            }
        }
    }
}

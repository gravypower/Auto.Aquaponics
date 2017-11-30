using System;
using System.Collections.Generic;
using System.Linq;
using Auto.Aquaponics.Components;
using ServiceStack;

namespace Auto.Aquaponics.AquaponicSystems
{
    public class AquaponicSystem
    {
        [ApiMember(ExcludeInSchema = true)]
        public Guid Id { get; set; }

        [ApiMember(Name = "Closed", Description = "Indicates if the system is closed",
            ParameterType = "body", DataType = "boolean")]
        public bool Closed { get; set; }

        [ApiMember(Name = "Name", Description = "The name of the aquaponic system",
            ParameterType = "body", DataType = "string", IsRequired = true)]
        public string Name { get; set; }

        [ApiMember(ExcludeInSchema = true)]
        public ICollection<Component> Components { get; set; }
        [ApiMember(ExcludeInSchema = true)]
        public ICollection<ComponentConnection> ComponentConnections { get; set; }

        public AquaponicSystem()
        {
            Closed = true;
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

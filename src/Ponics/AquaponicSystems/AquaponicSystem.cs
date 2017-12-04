using System;
using System.Collections.Generic;
using Ponics.Components;
using ServiceStack;

namespace Ponics.AquaponicSystems
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
        public IList<Component> Components { get; set; }

        [ApiMember(ExcludeInSchema = true)]
        public IList<ComponentConnection> ComponentConnections { get; set; }

        public AquaponicSystem()
        {
            Closed = true;
            Components = new List<Component>();
            ComponentConnections = new List<ComponentConnection>();
        }
    }
}

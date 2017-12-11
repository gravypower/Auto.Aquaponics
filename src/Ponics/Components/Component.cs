using System.Collections.Generic;
using System;
using ServiceStack;

namespace Ponics.Components
{
    public class Component
    {
        [ApiMember(ExcludeInSchema = true)]
        public Guid Id { get; set; }

        [ApiMember(Name = "Name", Description = "The name of a component",
            ParameterType = "body", DataType = "string", IsRequired = true)]
        public string Name { get; set; }

        [ApiMember(ExcludeInSchema = true)]
        public List<Guid> Organisms { get; set; }

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

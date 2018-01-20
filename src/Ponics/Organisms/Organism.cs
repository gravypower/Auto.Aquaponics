using System;
using System.Collections.Generic;
using Ponics.Organisms.Tolerances;
using ServiceStack;

namespace Ponics.Organisms
{
    public class Organism
    {
        [ApiMember(Name = "Name", Description = "The name of an organism",
            ParameterType = "body", DataType = "string", IsRequired = true)]
        public string Name { get; set; }

        [ApiMember(ExcludeInSchema = true)]
        public Guid Id { get; set; }

        [ApiMember(ExcludeInSchema = true)]
        public List<Tolerance> Tolerances { get; set; }

        public Organism()
        {
            Tolerances = new List<Tolerance>();
        }
    }
}
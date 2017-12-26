using System;
using System.Collections.Generic;
using Ponics.Analysis.Levels;
using ServiceStack;

namespace Ponics
{
    public abstract class PonicsSystem
    {
        [ApiMember(ExcludeInSchema = true)]
        public Guid Id { get; set; }

        [ApiMember(Name = "Name", Description = "The name of the aquaponic system",
            ParameterType = "body", DataType = "string", IsRequired = true)]
        public string Name { get; set; }

        [ApiMember(ExcludeInSchema = true)]
        public List<LevelReading> LevelReadings { get; set; }

        public PonicsSystem()
        {
            LevelReadings = new List<LevelReading>();
        }
    }
}

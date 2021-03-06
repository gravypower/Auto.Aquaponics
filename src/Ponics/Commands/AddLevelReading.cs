﻿using System;
using System.Collections.Generic;
using Ponics.Analysis.Levels;
using Ponics.Kernel.Commands;
using ServiceStack;

namespace Ponics.Commands
{
    [Api("Adds a level readings for system")]
    [Route("/systems/{SystemId}/reading", "POST")]
    public class AddLevelReading : ICommand, IDataCommand
    {
        [ApiMember(Name = "SystemId", Description = "The id of a System",
            ParameterType = "path", DataType = "string", IsRequired = true)]
        [ApiAllowableValues("SystemId", typeof(Guid))]
        public Guid SystemId { get; set; }

        public List<LevelReading> LevelReadings { get; set; }
    }
}
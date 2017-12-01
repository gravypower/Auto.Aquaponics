﻿using System;
using Auto.Aquaponics.Commands;
using ServiceStack;

namespace Auto.Aquaponics.Analysis.Levels
{
    public abstract class AddTolerance<TTolerance>: Command
        where TTolerance:Tolerance
    {
        [ApiMember(Name = "OrganismId", Description = "The id of an organism",
            ParameterType = "path", DataType = "string", IsRequired = true)]
        [ApiAllowableValues("OrganismId", typeof(Guid))]
        public Guid OrganismId { get; set; }

        [ApiMember(ExcludeInSchema = true)]
        public abstract TTolerance Tolerance { get; set; }
    }
}
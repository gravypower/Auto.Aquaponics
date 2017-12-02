﻿using ServiceStack;

namespace Ponics.Analysis.Levels.Iron
{
    [Api("Add Iron tolerance to an organism")]
    [Route("/organisms/{OrganismId}/tolerances/iron", "POST")]
    public class AddIronTolerance: AddTolerance<IronTolerance>
    {
        public override IronTolerance Tolerance { get; set; }
    }
}
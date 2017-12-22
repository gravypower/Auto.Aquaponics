using System;
using System.Collections.Generic;
using ServiceStack;
using Ponics.Kernel.Data;
using Ponics.Queries;

namespace Ponics.Organisms
{
    [Api("Get all organisms")]
    [Route("/organisms", "GET")]
    public class GetOrganisms : Query<List<Organism>>, IDataQuery<List<Organism>>
    {
        public Guid[] OrganismsIds { get; set; }
    }
}

using System;
using System.Collections.Generic;
using Ponics.Kernel.Queries;
using ServiceStack;

namespace Ponics.Organisms.Queries
{
    [Api("Get all organisms")]
    [Route("/organisms", "GET")]
    public class GetOrganisms : IQuery<List<Organism>>, IDataQuery<List<Organism>>
    {
        public Guid[] OrganismsIds { get; set; }
    }
}

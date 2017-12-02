using System.Collections.Generic;
using ServiceStack;
using Ponics.Kernel.Data;
using Ponics.Queries;

namespace Ponics.Organisms
{
    [Api("Get all organisms")]
    [Route("/organisms", "GET")]
    public class GetAllOrganisms : Query<IList<Organism>>, IDataQuery<IList<Organism>>
    {
    }
}

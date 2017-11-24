using System.Collections.Generic;
using Auto.Aquaponics.Kernel.DataQuery;
using ServiceStack;

namespace Auto.Aquaponics.Organisms
{
    [Api("Get all Organisms")]
    [Route("/organisms", "GET")]
    public class GetAllOrganisms : IDataQuery<IList<Organism>>, Query.IQuery<IList<Organism>>
    {
    }
}

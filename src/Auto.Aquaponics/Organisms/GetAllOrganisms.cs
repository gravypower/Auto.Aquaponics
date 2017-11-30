using System.Collections.Generic;
using Auto.Aquaponics.Kernel.Data;
using ServiceStack;
using Auto.Aquaponics.Queries;

namespace Auto.Aquaponics.Organisms
{
    [Api("Get all organisms")]
    [Route("/organisms", "GET")]
    public class GetAllOrganisms : Query<IList<Organism>>, IDataQuery<IList<Organism>>
    {
    }
}

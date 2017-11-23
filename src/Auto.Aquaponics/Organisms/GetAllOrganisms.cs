using System.Collections.Generic;
using Auto.Aquaponics.Kernel.DataQuery;
using Auto.Aquaponics.Query;

namespace Auto.Aquaponics.Organisms
{
    public class GetAllOrganisms : IDataQuery<IList<Organism>>, IQuery<IList<Organism>>
    {
    }
}

using System.Collections.Generic;
using Auto.Aquaponics.Kernel.Data;
using ServiceStack;
using Auto.Aquaponics.Queries;

namespace Auto.Aquaponics.AquaponicSystems
{
    [Api("Returns a list of all Aquaponic Systems")]
    [Route("/systems", "GET")]
    public class GetAllSystems: Query<IList<AquaponicSystem>>, IDataQuery<IList<AquaponicSystem>>
    {
    }
}
using System.Collections.Generic;
using ServiceStack;

namespace Auto.Aquaponics.AquaponicSystems
{
    [Api("Returns a list of all Aquaponic Systems")]
    [Route("/systems", "GET")]
    public class GetAllSystems: Query.IQuery<IList<AquaponicSystem>>
    {
    }
}
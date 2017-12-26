using System.Collections.Generic;
using Ponics.Kernel.Data;
using Ponics.Queries;
using ServiceStack;

namespace Ponics.Aquaponics 
{
    [Api("Returns a list of all Aquaponic Systems")]
    [Route("/aquaponic/systems", "GET")]
    public class GetAllSystems: Query<List<AquaponicSystem>>, IDataQuery<List<AquaponicSystem>>
    {
    }
}
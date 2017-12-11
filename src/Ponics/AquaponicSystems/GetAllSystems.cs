using System.Collections.Generic;
using ServiceStack;
using Ponics.Kernel.Data;
using Ponics.Queries;

namespace Ponics.AquaponicSystems
{
    [Api("Returns a list of all Aquaponic Systems")]
    [Route("/systems", "GET")]
    public class GetAllSystems: Query<List<AquaponicSystem>>, IDataQuery<List<AquaponicSystem>>
    {
    }
}
using System.Collections.Generic;
using Ponics.Kernel.Data;
using Ponics.Kernel.Queries;
using Ponics.Queries;
using ServiceStack;

namespace Ponics.Aquaponics 
{
    [Api("Returns a list of all Aquaponic Systems")]
    [Route("/systems/aquaponic", "GET")]
    [Tag("aquaponic")]
    public class GetAllSystems: Query<List<AquaponicSystem>>, IDataQuery<List<AquaponicSystem>>
    {
    }
}
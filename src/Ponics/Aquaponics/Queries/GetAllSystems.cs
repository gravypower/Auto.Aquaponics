using System.Collections.Generic;
using Ponics.Kernel.Queries;
using ServiceStack;

namespace Ponics.Aquaponics.Queries 
{
    [Api("Returns a list of all Aquaponic Systems")]
    [Route("/systems/aquaponic", "GET")]
    [Tag("aquaponic")]
    public class GetAllSystems: IQuery<List<AquaponicSystem>>, IDataQuery<List<AquaponicSystem>>
    {
    }
}
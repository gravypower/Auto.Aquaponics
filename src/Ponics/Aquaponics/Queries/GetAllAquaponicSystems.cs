using Ponics.Queries;
using ServiceStack;

namespace Ponics.Aquaponics.Queries 
{
    [Api("Returns a list of all Aquaponic Systems")]
    [Route("/systems/aquaponic", "GET")]
    [Tag("aquaponic")]
    public class GetAllAquaponicSystems: GetAllPonicsSystems<AquaponicSystem>
    {
    }
}
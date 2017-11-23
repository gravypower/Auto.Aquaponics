using System.Linq;
using Auto.Aquaponics.AquaponicSystems;
using Auto.Aquaponics.Query;

namespace Auto.Aquaponics.HardCodedData
{
    public class GetSystemHandler : IQueryHandler<GetSystem, AquaponicSystem>
    {
        public AquaponicSystem Handle(GetSystem query)
        {
            var allSystems = new GetAllSystemsHandler().Handle(new GetAllSystems());

            return allSystems.Single(s => s.Id == query.Id);
        }
    }
}

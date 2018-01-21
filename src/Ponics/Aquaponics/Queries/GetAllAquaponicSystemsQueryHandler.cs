using System.Collections.Generic;
using System.Linq;
using Ponics.Kernel.Queries;
using Ponics.Queries;

namespace Ponics.Aquaponics.Queries
{
    public class GetAllAquaponicSystemsQueryHandler : GetAllPonicsSystemsQueryHandler<GetAllAquaponicSystems, AquaponicSystem>
    {
        private readonly IDataQueryHandler<GetAllAquaponicSystems, List<AquaponicSystem>> _getAllSystemsDataQueryHandler;

        public GetAllAquaponicSystemsQueryHandler(IDataQueryHandler<GetAllAquaponicSystems, List<AquaponicSystem>> getAllSystemsDataQueryHandler)
        {
            _getAllSystemsDataQueryHandler = getAllSystemsDataQueryHandler;
        }

        public override List<AquaponicSystem> DoHandle(GetAllAquaponicSystems query)
        {
            return _getAllSystemsDataQueryHandler
                .Handle(query)
                .Where(s => s.GetType() == typeof(AquaponicSystem))
                .ToList();
        }
    }
}

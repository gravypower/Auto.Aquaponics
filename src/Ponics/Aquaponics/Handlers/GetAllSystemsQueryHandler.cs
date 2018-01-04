using System.Collections.Generic;
using System.Linq;
using Ponics.Kernel.Data;
using Ponics.Kernel.Queries;
using Ponics.Queries;

namespace Ponics.Aquaponics.Handlers
{
    public class GetAllSystemsQueryHandler : IQueryHandler<GetAllSystems, List<AquaponicSystem>>
    {
        private readonly IDataQueryHandler<GetAllSystems, List<AquaponicSystem>> _getAllSystemsDataQueryHandler;

        public GetAllSystemsQueryHandler(IDataQueryHandler<GetAllSystems, List<AquaponicSystem>> getAllSystemsDataQueryHandler)
        {
            _getAllSystemsDataQueryHandler = getAllSystemsDataQueryHandler;
        }

        public List<AquaponicSystem> Handle(GetAllSystems query)
        {
            return _getAllSystemsDataQueryHandler
                .Handle(query)
                .Where(s => s.GetType() == typeof(AquaponicSystem))
                .ToList();
        }
    }
}

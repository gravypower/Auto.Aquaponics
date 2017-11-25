using System.Collections.Generic;
using System.Linq;
using Auto.Aquaponics.Kernel.Data;
using Auto.Aquaponics.Queries;

namespace Auto.Aquaponics.AquaponicSystems
{
    public class GetSystemQueryHandler : IQueryHandler<GetSystem, AquaponicSystem>
    {
        private readonly IDataQueryHandler<GetAllSystems, IList<AquaponicSystem>> _getAllSystemsDataQueryHandler;

        public GetSystemQueryHandler(IDataQueryHandler<GetAllSystems, IList<AquaponicSystem>> getAllSystemsDataQueryHandler)
        {
            _getAllSystemsDataQueryHandler = getAllSystemsDataQueryHandler;
        }
        public AquaponicSystem Handle(GetSystem query)
        {
            return _getAllSystemsDataQueryHandler.Handle(new GetAllSystems())
                .Single(s => s.Id == query.Id);
        }
    }
}
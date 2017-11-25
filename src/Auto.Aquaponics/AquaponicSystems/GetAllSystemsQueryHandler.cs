using System.Collections.Generic;
using Auto.Aquaponics.Kernel.Data;
using Auto.Aquaponics.Queries;

namespace Auto.Aquaponics.AquaponicSystems
{
    public class GetAllSystemsQueryHandler : IQueryHandler<GetAllSystems, IList<AquaponicSystem>>
    {
        private readonly IDataQueryHandler<GetAllSystems, IList<AquaponicSystem>> _getAllSystemsDataQueryHandler;

        public GetAllSystemsQueryHandler(IDataQueryHandler<GetAllSystems, IList<AquaponicSystem>> getAllSystemsDataQueryHandler)
        {
            _getAllSystemsDataQueryHandler = getAllSystemsDataQueryHandler;
        }

        public IList<AquaponicSystem> Handle(GetAllSystems query)
        {
            return _getAllSystemsDataQueryHandler.Handle(query);
        }
    }
}

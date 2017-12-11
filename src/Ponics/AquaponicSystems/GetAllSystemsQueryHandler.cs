using System.Collections.Generic;
using Ponics.Kernel.Data;
using Ponics.Queries;

namespace Ponics.AquaponicSystems
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
            return _getAllSystemsDataQueryHandler.Handle(query);
        }
    }
}

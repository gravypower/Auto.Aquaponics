using System.Collections.Generic;
using System.Linq;
using Ponics.Kernel.Data;
using Ponics.Queries;

namespace Ponics.Aquaponics.Handlers
{
    public class GetSystemQueryHandler : IQueryHandler<GetSystem, AquaponicSystem>
    {
        private readonly IDataQueryHandler<GetAllSystems, List<AquaponicSystem>> _getAllSystemsDataQueryHandler;

        public GetSystemQueryHandler(IDataQueryHandler<GetAllSystems, List<AquaponicSystem>> getAllSystemsDataQueryHandler)
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
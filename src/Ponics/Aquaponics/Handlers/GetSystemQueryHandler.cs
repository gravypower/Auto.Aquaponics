using System.Collections.Generic;
using System.Linq;
using Ponics.Kernel.Queries;
using Ponics.Queries;

namespace Ponics.Aquaponics.Handlers
{
    public class GetSystemQueryHandler : IQueryHandler<GetSystem, AquaponicSystem>
    {
        private readonly IDataQueryHandler<GetSystem, AquaponicSystem> _getSystemDataQueryHandler;

        public GetSystemQueryHandler(IDataQueryHandler<GetSystem, AquaponicSystem> getSystemDataQueryHandler)
        {
            _getSystemDataQueryHandler = getSystemDataQueryHandler;
        }
        public AquaponicSystem Handle(GetSystem query)
        {
            return _getSystemDataQueryHandler.Handle(query);
        }
    }
}
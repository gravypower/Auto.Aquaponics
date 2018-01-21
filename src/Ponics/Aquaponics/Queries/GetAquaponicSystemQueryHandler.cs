using Ponics.Kernel.Queries;

namespace Ponics.Aquaponics.Queries
{
    public class GetAquaponicSystemQueryHandler : IQueryHandler<GetAquaponicSystem, AquaponicSystem>
    {
        private readonly IDataQueryHandler<GetAquaponicSystem, AquaponicSystem> _getSystemDataQueryHandler;

        public GetAquaponicSystemQueryHandler(IDataQueryHandler<GetAquaponicSystem, AquaponicSystem> getSystemDataQueryHandler)
        {
            _getSystemDataQueryHandler = getSystemDataQueryHandler;
        }
        public AquaponicSystem Handle(GetAquaponicSystem query)
        {
            return _getSystemDataQueryHandler.Handle(query);
        }
    }
}
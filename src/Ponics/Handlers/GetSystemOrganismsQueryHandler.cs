using System.Collections.Generic;
using System.Linq;
using Ponics.Aquaponics;
using Ponics.Kernel.Queries;
using Ponics.Organisms;
using Ponics.Queries;

namespace Ponics.Handlers
{
    public class GetSystemOrganismsQueryHandler : IQueryHandler<GetSystemOrganisms, List<Organism>>
    {
        private readonly IDataQueryHandler<GetSystem, AquaponicSystem> _getSystemDataQueryHandler;
        private readonly IDataQueryHandler<GetOrganisms, List<Organism>> _getAllOrganismsDataQueryHandler;

        public GetSystemOrganismsQueryHandler(
            IDataQueryHandler<GetSystem, AquaponicSystem> getSystemDataQueryHandler,
            IDataQueryHandler<GetOrganisms, List<Organism>> getAllOrganismsDataQueryHandler
            )
        {
            _getSystemDataQueryHandler = getSystemDataQueryHandler;
            _getAllOrganismsDataQueryHandler = getAllOrganismsDataQueryHandler;
        }

        public List<Organism> Handle(GetSystemOrganisms query)
        {
            var system = _getSystemDataQueryHandler.Handle(new GetSystem {SystemId = query.SystemId});
            var organisms = _getAllOrganismsDataQueryHandler.Handle(new GetOrganisms());

            var result = new List<Organism>();
            foreach (var component in system.Components)
            {
                foreach (var organismId in component.Organisms)
                {
                    if (result.Any(o => o.Id == organismId)) continue;

                    var organism = organisms.SingleOrDefault(o => o.Id == organismId);
                    result.Add(organism);
                }
            }

            return result;
        }
    }
}

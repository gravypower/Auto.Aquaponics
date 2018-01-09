using System.Collections.Generic;
using System.Linq;
using Ponics.Aquaponics;
using Ponics.Aquaponics.Queries;
using Ponics.Kernel.Queries;
using Ponics.Organisms;
using Ponics.Organisms.Queries;

namespace Ponics.Components.Queries
{
    public class GetComponentOrganismsQueryHandler : IQueryHandler<GetComponentOrganisms, List<Organism>>
    {
        private readonly IDataQueryHandler<GetSystem, AquaponicSystem> _getSystemDataQueryHandler;
        private readonly IDataQueryHandler<GetOrganisms, List<Organism>> _getAllOrganismsDataQueryHandler;

        public GetComponentOrganismsQueryHandler(
            IDataQueryHandler<GetSystem, AquaponicSystem> getSystemDataQueryHandler,
            IDataQueryHandler<GetOrganisms, List<Organism>> getAllOrganismsDataQueryHandler
        )
        {
            _getSystemDataQueryHandler = getSystemDataQueryHandler;
            _getAllOrganismsDataQueryHandler = getAllOrganismsDataQueryHandler;
        }
        public List<Organism> Handle(GetComponentOrganisms query)
        {
            var system = _getSystemDataQueryHandler.Handle(new GetSystem
            {
                SystemId = query.SystemId
            });

            var component = system.Components.Single(c => c.Id == query.ComponentId);

            var organisms = _getAllOrganismsDataQueryHandler.Handle(new GetOrganisms
            {
                OrganismsIds = component.Organisms
            });
            
            return organisms.Where(o => component.Organisms.Contains(o.Id)).ToList();
        }
    }
}

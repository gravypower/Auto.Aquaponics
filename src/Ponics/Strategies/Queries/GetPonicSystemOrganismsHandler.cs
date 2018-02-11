using System.Collections.Generic;
using System.Linq;
using Ponics.Aquaponics;
using Ponics.Aquaponics.Queries;
using Ponics.Kernel.Queries;
using Ponics.Organisms;
using Ponics.Organisms.Queries;

namespace Ponics.Strategies.Queries
{
    public class GetPonicSystemOrganismsHandler: IQueryStrategyHandler<GetPonicSystemOrganisms, List<Organism>>
    {
        private readonly IDataQueryHandler<GetAquaponicSystem, AquaponicSystem> _getSystemDataQueryHandler;
        private readonly IDataQueryHandler<GetOrganisms, List<Organism>> _getAllOrganismsDataQueryHandler;

        public GetPonicSystemOrganismsHandler(
            IDataQueryHandler<GetAquaponicSystem, AquaponicSystem> getSystemDataQueryHandler,
            IDataQueryHandler<GetOrganisms, List<Organism>> getAllOrganismsDataQueryHandler
        )
        {
            _getSystemDataQueryHandler = getSystemDataQueryHandler;
            _getAllOrganismsDataQueryHandler = getAllOrganismsDataQueryHandler;
        }

        public List<Organism> Handle(GetPonicSystemOrganisms query)
        {
            var system = _getSystemDataQueryHandler.Handle(new GetAquaponicSystem { SystemId = query.SystemId });
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

            result.AddRange(organisms.Where(o => !result.Contains(o) && system.SystemWideOrganisms.Contains(o.Id)));

            return result;
        }
    }
}

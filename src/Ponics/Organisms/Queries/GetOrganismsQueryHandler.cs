using System.Collections.Generic;
using System.Linq;
using Ponics.Kernel.Queries;

namespace Ponics.Organisms.Queries
{
    public class GetOrganismsQueryHandler : IQueryHandler<GetOrganisms, List<Organism>>
    {
        private readonly IDataQueryHandler<GetOrganisms, List<Organism>> _getAllOrganismsDataQueryHandler;

        public GetOrganismsQueryHandler(
            IDataQueryHandler<GetOrganisms, List<Organism>> getAllOrganismsDataQueryHandler)
        {
            _getAllOrganismsDataQueryHandler = getAllOrganismsDataQueryHandler;
        }

        public List<Organism> Handle(GetOrganisms query)
        {
            var organisms = _getAllOrganismsDataQueryHandler.Handle(query);

            if (query.OrganismsIds != null)
                return organisms.Where(o => query.OrganismsIds.Contains(o.Id)).ToList();

            return organisms;

        }
    }
}

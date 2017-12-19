using System.Collections.Generic;
using System.Linq;
using Ponics.Kernel.Data;
using Ponics.Queries;

namespace Ponics.Organisms.Handlers
{
    public class GetOrganismQueryHandler : IQueryHandler<GetOrganism, Organism>
    {
        private readonly IDataQueryHandler<GetAllOrganisms, List<Organism>> _getAllOrganismsDataQueryHandler;

        public GetOrganismQueryHandler(IDataQueryHandler<GetAllOrganisms, List<Organism>> getAllOrganismsDataQueryHandler)
        {
            _getAllOrganismsDataQueryHandler = getAllOrganismsDataQueryHandler;
        }

        public Organism Handle(GetOrganism query)
        {
            return _getAllOrganismsDataQueryHandler.Handle(new GetAllOrganisms())
                .Single(o => o.Id == query.Id);
        }
    }
}

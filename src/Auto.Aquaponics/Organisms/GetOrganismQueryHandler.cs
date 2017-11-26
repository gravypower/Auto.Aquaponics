using System.Collections.Generic;
using System.Linq;
using Auto.Aquaponics.Kernel.Data;
using Auto.Aquaponics.Queries;

namespace Auto.Aquaponics.Organisms
{
    public class GetOrganismQueryHandler : IQueryHandler<GetOrganism, Organism>
    {
        private readonly IDataQueryHandler<GetAllOrganisms, IList<Organism>> _getAllOrganismsDataQueryHandler;

        public GetOrganismQueryHandler(IDataQueryHandler<GetAllOrganisms, IList<Organism>> getAllOrganismsDataQueryHandler)
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

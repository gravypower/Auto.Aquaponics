using System.Collections.Generic;
using Auto.Aquaponics.Kernel.Data;
using Auto.Aquaponics.Queries;

namespace Auto.Aquaponics.Organisms
{
    public class GetAllOrganismsQueryHandler : IQueryHandler<GetAllOrganisms, IList<Organism>>
    {
        private readonly IDataQueryHandler<GetAllOrganisms, IList<Organism>> _getAllOrganismsDataQueryHandler;

        public GetAllOrganismsQueryHandler(
            IDataQueryHandler<GetAllOrganisms, IList<Organism>> getAllOrganismsDataQueryHandler)
        {
            _getAllOrganismsDataQueryHandler = getAllOrganismsDataQueryHandler;
        }

        public IList<Organism> Handle(GetAllOrganisms query)
        {
            return _getAllOrganismsDataQueryHandler.Handle(query);
        }
    }
}

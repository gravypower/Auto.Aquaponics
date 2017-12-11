using System.Collections.Generic;
using Ponics.Kernel.Data;
using Ponics.Queries;

namespace Ponics.Organisms
{
    public class GetAllOrganismsQueryHandler : IQueryHandler<GetAllOrganisms, List<Organism>>
    {
        private readonly IDataQueryHandler<GetAllOrganisms, List<Organism>> _getAllOrganismsDataQueryHandler;

        public GetAllOrganismsQueryHandler(
            IDataQueryHandler<GetAllOrganisms, List<Organism>> getAllOrganismsDataQueryHandler)
        {
            _getAllOrganismsDataQueryHandler = getAllOrganismsDataQueryHandler;
        }

        public List<Organism> Handle(GetAllOrganisms query)
        {
            return _getAllOrganismsDataQueryHandler.Handle(query);
        }
    }
}

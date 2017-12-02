using System.Collections.Generic;
using Ponics.Kernel.Data;
using Ponics.Queries;

namespace Ponics.Organisms
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

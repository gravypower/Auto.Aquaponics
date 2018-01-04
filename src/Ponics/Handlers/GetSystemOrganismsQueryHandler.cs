using System.Collections.Generic;
using Ponics.Kernel.Queries;
using Ponics.Organisms;
using Ponics.Queries;
using Ponics.Strategies;

namespace Ponics.Handlers
{
    public class GetSystemOrganismsQueryHandler : IQueryHandler<GetSystemOrganisms, List<Organism>>
    {
        private readonly IQueryStrategyHandler<GetPonicSystemOrganisms, List<Organism>> _getPonicSystemOrganismsHandler;

        public GetSystemOrganismsQueryHandler(
            IQueryStrategyHandler<GetPonicSystemOrganisms, List<Organism>> getPonicSystemOrganismsHandler
            )
        {
            _getPonicSystemOrganismsHandler = getPonicSystemOrganismsHandler;
        }

        public List<Organism> Handle(GetSystemOrganisms query)
        {
            return _getPonicSystemOrganismsHandler.Handle(new GetPonicSystemOrganisms {SystemId = query.SystemId});
        }
    }
}

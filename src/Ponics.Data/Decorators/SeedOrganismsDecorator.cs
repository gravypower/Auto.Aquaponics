using System.Collections.Generic;
using System.Linq;
using Ponics.Data.Seed;
using Ponics.Kernel.Commands;
using Ponics.Kernel.Queries;
using Ponics.Organisms;
using Ponics.Organisms.Commands;
using Ponics.Organisms.Queries;

namespace Ponics.Data.Decorators
{
    public class SeedOrganismsDecorator: IDataQueryHandler<GetOrganisms, List<Organism>>
    {
        private readonly IDataQueryHandler<GetOrganisms, List<Organism>> _decorated;
        private readonly IDataCommandHandler<AddOrganism> _addOrganisms;
        private readonly SeedData<Organism> _organisms;

        public SeedOrganismsDecorator(
            IDataQueryHandler<GetOrganisms, List<Organism>> decorated,
            IDataCommandHandler<AddOrganism> addOrganisms,
            SeedData<Organism> organisms
            )
        {
            _decorated = decorated;
            _addOrganisms = addOrganisms;
            _organisms = organisms;
        }

        public List<Organism> Handle(GetOrganisms query)
        {
            var result = _decorated.Handle(query);

            if (result.Any()) return result;
            foreach (var organism in _organisms.GetSeedData())
            {
                _addOrganisms.Handle(new AddOrganism { Organism = organism });
            }

            result = _decorated.Handle(query);

            return result;
        }
    }
}

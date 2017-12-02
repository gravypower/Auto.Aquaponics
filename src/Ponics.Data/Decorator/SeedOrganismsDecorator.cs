using System.Collections.Generic;
using System.Linq;
using Ponics.Data.Seed;
using Ponics.Kernel.Data;
using Ponics.Organisms;

namespace Ponics.Data.Decorator
{
    public class SeedOrganismsDecorator: IDataQueryHandler<GetAllOrganisms, IList<Organism>>
    {
        private readonly IDataQueryHandler<GetAllOrganisms, IList<Organism>> _decorated;
        private readonly IDataCommandHandler<AddOrganism> _addOrganisms;
        private readonly SeedData<Organism> _organisms;

        public SeedOrganismsDecorator(
            IDataQueryHandler<GetAllOrganisms, IList<Organism>> decorated,
            IDataCommandHandler<AddOrganism> addOrganisms,
            SeedData<Organism> organisms
            )
        {
            _decorated = decorated;
            _addOrganisms = addOrganisms;
            _organisms = organisms;
        }

        public IList<Organism> Handle(GetAllOrganisms query)
        {
            var result = _decorated.Handle(query);

            if (result.Any()) return result;
            foreach (var organism in _organisms.GetSeedData())
            {
                _addOrganisms.Handle(new AddOrganism{Organism = organism });
            }
            result = _decorated.Handle(query);

            return result;
        }
    }
}

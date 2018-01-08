using System.Collections.Generic;
using System.Linq;
using Ponics.Aquaponics;
using Ponics.Aquaponics.Commands;
using Ponics.Aquaponics.Queries;
using Ponics.Data.Seed;
using Ponics.Kernel.Commands;
using Ponics.Kernel.Queries;

namespace Ponics.Data.Decorator
{
    public class SeedAquaponicSystemsDecorator : IDataQueryHandler<GetAllSystems, List<AquaponicSystem>>
    {
        private readonly IDataQueryHandler<GetAllSystems, List<AquaponicSystem>> _decorated;
        private readonly IDataCommandHandler<AddSystem> _addSystem;
        private readonly SeedData<AquaponicSystem> _aquaponicSystems;

        public SeedAquaponicSystemsDecorator(
            IDataQueryHandler<GetAllSystems, List<AquaponicSystem>> decorated,
            IDataCommandHandler<AddSystem> addSystem,
            SeedData<AquaponicSystem> aquaponicSystems
            )
        {
            _decorated = decorated;
            _addSystem = addSystem;
            _aquaponicSystems = aquaponicSystems;
        }

        public List<AquaponicSystem> Handle(GetAllSystems query)
        {
            var result = _decorated.Handle(query);

            if (result.Any()) return result;
            foreach (var aquaponicSystem in _aquaponicSystems.GetSeedData())
            {
                _addSystem.Handle(new AddSystem { System= aquaponicSystem });
            }

            result = _decorated.Handle(query);

            return result;
        }
    }
}

using System.Collections.Generic;
using Ponics.Aquaponics;
using Ponics.Aquaponics.Queries;
using Ponics.Data.Decorators;
using Ponics.Data.Seed;
using Ponics.Kernel.Queries;
using Ponics.Organisms;
using Ponics.Organisms.Queries;
using SimpleInjector;

namespace Ponics.Api.CompositionRoot
{
    public class BootstrapSeedData : IBootstrap
    {
        public void Bootstrap(Container container)
        {
            container.Register(typeof(SeedData<>), new[] { typeof(SeedData<>).Assembly });

            container.RegisterDecorator(
                typeof(IDataQueryHandler<GetOrganisms, List<Organism>>),
                typeof(SeedOrganismsDecorator));

            container.RegisterDecorator(
                typeof(IDataQueryHandler<GetAllAquaponicSystems, List<AquaponicSystem>>),
                typeof(SeedAquaponicSystemsDecorator));
        }
    }
}

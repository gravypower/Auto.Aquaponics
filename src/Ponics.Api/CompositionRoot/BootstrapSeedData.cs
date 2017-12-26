using System.Collections.Generic;
using Ponics.Aquaponics;
using Ponics.Data.Decorator;
using Ponics.Data.Seed;
using Ponics.Kernel.Data;
using Ponics.Organisms;
using SimpleInjector;

namespace Ponics.Api.CompositionRoot
{
    public class BootstrapSeedData:IBootstrap
    {
        public void Bootstrap(Container container)
        {
            container.Register(typeof(SeedData<>), new[] { typeof(SeedData<>).Assembly });

            container.RegisterDecorator(
                typeof(IDataQueryHandler<GetOrganisms, List<Organism>>),
                typeof(SeedOrganismsDecorator));

            container.RegisterDecorator(
                typeof(IDataQueryHandler<GetAllSystems, List<AquaponicSystem>>),
                typeof(SeedAquaponicSystemsDecorator));
        }
    }
}

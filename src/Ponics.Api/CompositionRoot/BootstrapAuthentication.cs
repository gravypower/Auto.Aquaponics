using System.Collections.Generic;
using Ponics.Api.Auth;
using Ponics.Aquaponics;
using Ponics.Aquaponics.Queries;
using Ponics.Kernel.Queries;
using SimpleInjector;

namespace Ponics.Api.CompositionRoot
{
    public class BootstrapAuthentication : IBootstrap
    {
        public void Bootstrap(Container container)
        {
            container.RegisterDecorator(
                typeof(IDataQueryHandler<GetAllAquaponicSystems, List<AquaponicSystem>>),
                typeof(AuthoriseUserAccessToPonicsSystems<GetAllAquaponicSystems, AquaponicSystem>));
        }
    }
}

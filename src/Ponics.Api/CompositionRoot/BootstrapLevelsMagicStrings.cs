using System.Linq;
using Ponics.Analysis.Levels.MagicStrings;
using Ponics.Kernel;
using SimpleInjector;

namespace Ponics.Api.CompositionRoot
{
    public class BootstrapLevelsMagicStrings:IBootstrap
    {
        public void Bootstrap(Container container)
        {
            container.Register<IToleranceMagicStrings, ToleranceMagicStrings>();
            var levelMagicStringsAssembly = typeof(ILevelsMagicStrings).Assembly;

            var registrations =
                from type in levelMagicStringsAssembly.GetExportedTypes()
                where typeof(ILevelsMagicStrings).IsAssignableFrom(type)
                where !type.IsAbstract
                select type;

            foreach (var reg in registrations)
            {
                container.Register(reg.GetInterfaces().Single(i => i != typeof(ILevelsMagicStrings)), reg);
            }
        }
    }
}

using SimpleInjector;

namespace Ponics.Api.CompositionRoot
{
    public interface IBootstrap
    {
        void Bootstrap(Container container);
    }
}

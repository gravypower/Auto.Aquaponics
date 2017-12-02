using ServiceStack.Configuration;
using SimpleInjector;

namespace Ponics.Api
{
    public class SimpleInjectorIocAdapter : IContainerAdapter
    {
        private readonly Container _container;

        public SimpleInjectorIocAdapter(Container container)
        {
            _container = container;
        }

        public T Resolve<T>()
        {
            return (T)_container.GetInstance(typeof(T));
        }

        public T TryResolve<T>()
        {
            var registration = _container.GetRegistration(typeof(T));
            return (T)registration?.GetInstance();
        }
    }
}

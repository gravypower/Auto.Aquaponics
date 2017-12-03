using System;
using Funq;
using ServiceStack;
using ServiceStack.Api.OpenApi;
using ServiceStack.Text;

namespace Ponics.Api
{
    public class AppHost : AppHostBase
    {
        /// <summary>
        /// Base constructor requires a Name and Assembly where web service implementation is located
        /// </summary>
        public AppHost() : base("Ponics.Api", typeof(QueryService).Assembly)
        {
            Licensing.RegisterLicense(Environment.GetEnvironmentVariable("servicestack:license"));
        }

        /// <summary>
        /// Application specific configuration
        /// This method should initialize any IoC resources utilized by your web service classes.
        /// </summary>
        public override void Configure(Container container)
        {
            Plugins.Add(new OpenApiFeature());

            JsConfig.ExcludeTypeInfo = true;

            var sic = Bootstrapper.Bootstrap();
            container.Adapter = new SimpleInjectorIocAdapter(sic);
   
            var queryServiceType = TypeFactory.GenerateQueryServices(Bootstrapper.GetQueryTypes(), typeof(QueryService));
            RegisterService(queryServiceType);
            
            var commandSserviceType = TypeFactory.GenerateCommandServices(Bootstrapper.GetCommandTypes(), typeof(CommandService));
            RegisterService(commandSserviceType);
        }
     }
}
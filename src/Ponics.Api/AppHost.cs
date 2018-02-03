using System;
using Funq;
using Microsoft.AspNetCore.Builder;
using NodaTime;
using NodaTime.Text;
using Ponics.Api.Auth;
using Ponics.Api.CompositionRoot;
using Ponics.Api.Services;
using ServiceStack;
using ServiceStack.Api.OpenApi;
using ServiceStack.Auth;
using ServiceStack.Text;

namespace Ponics.Api
{
    public class AppHost : AppHostBase
    {
        private readonly IApplicationBuilder _app;

        /// <summary>
        /// Base constructor requires a Name and Assembly where web service implementation is located
        /// </summary>
        public AppHost(IApplicationBuilder app) : base("Ponics.Api", typeof(AppHost).Assembly)
        {
            _app = app;
            Licensing.RegisterLicense(Environment.GetEnvironmentVariable("SERVICESTACK_LICENSE"));
        }

        /// <summary>
        /// Application specific configuration
        /// This method should initialize any IoC resources utilized by your web service classes.
        /// </summary>
        public override void Configure(Container container)
        {
            var auth0Domain = Environment.GetEnvironmentVariable("auth0_domain");
            var auth0ClientId = Environment.GetEnvironmentVariable("auth0_client_id");

            Plugins.Add(new AuthFeature(() => new AuthUserSession(),
                new IAuthProvider[] {
                    new JsonWebTokenAuthProvider(auth0Domain, auth0ClientId)
                }));

            Plugins.Add(new OpenApiFeature());

            var allowOriginWhitelist = Environment.GetEnvironmentVariable("ALLOW_ORIGIN_WHITELIST");
            Plugins.Add(
                new CorsFeature(
                    allowedHeaders: "Content-Type, Authorization",
                    allowCredentials: true,
                    allowOriginWhitelist: allowOriginWhitelist.Split(',')
                )
            );

            JsConfig.ExcludeTypeInfo = true;
            JsConfig<ZonedDateTime>.SerializeFn = SerializeZoneDateTime;
            JsConfig<ZonedDateTime>.DeSerializeFn = ParseZoneDateTime;

            var sic = Bootstrapper.Bootstrap();
            container.Adapter = new SimpleInjectorIocAdapter(sic);
   
            var queryServiceType = TypeFactory.GenerateQueryServices(Bootstrapper.GetQueryTypes(), typeof(QueryService));
            RegisterService(queryServiceType);
            
            var commandSserviceType = TypeFactory.GenerateCommandServices(Bootstrapper.GetCommandTypes(), typeof(CommandService));
            RegisterService(commandSserviceType);

            
        }

        private static string SerializeZoneDateTime(ZonedDateTime datetime)
        {
            return ZonedDateTimePattern.CreateWithInvariantCulture("G", DateTimeZoneProviders.Tzdb).Format(datetime);
        }

        private static ZonedDateTime ParseZoneDateTime(string datetime)
        {
            return ZonedDateTimePattern.CreateWithInvariantCulture("G", DateTimeZoneProviders.Tzdb)
                .Parse(datetime)
                .Value;
        }
    }
}
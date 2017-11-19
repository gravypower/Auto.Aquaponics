using System;
using ServiceStack;
using Auto.Aquaponics.Api.ServiceModel;

namespace Auto.Aquaponics.Api.ServiceInterface
{
    public class MyServices : Service
    {
        public object Any(Hello request)
        {
            return new HelloResponse { Result = "Hello, {0}!".Fmt(request.Name) };
        }
    }
}

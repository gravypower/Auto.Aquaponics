using System;
using Microsoft.AspNetCore.Http;
using ServiceStack.Text;

namespace Ponics.Api.Auth
{
    public class Context
    {
        private readonly IHttpContextAccessor _accessor;

        public Guid UserId
        {
            get
            {
                var appMetaData = _accessor.HttpContext.Items["appMetaData"] as JsonObject;

                return Guid.Parse(appMetaData["simpleponics_id"]);
            }
        }

        public Context(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }
    }
}
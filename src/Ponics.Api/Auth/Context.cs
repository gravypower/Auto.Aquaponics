using System;
using ServiceStack;
using ServiceStack.Auth;

namespace Ponics.Api.Auth
{
    public static class Context
    {
        public static Guid UserId
        {
            get
            {
                var session = SessionFeature.GetOrCreateSession<IAuthSession>();

                return Guid.Parse(session.UserAuthId);
            }
        }
    }
}
using System;
using Ponics.Utils;
using ServiceStack;

namespace Ponics.Api.Services
{
    [Api("Generates a new Guid for use as a UserId")]
    [Route("/user/id/{SharedSecret}", "GET")]
    public class GetNewUserId
    {
        public string SharedSecret { get; set; }
    }

    public class UserId
    {
        public Guid Guid { get; set; }
    }

    public class GetNewUserIdService : Service
    {
        private readonly string _sharedSecret;

        public GetNewUserIdService()
        {
            _sharedSecret = Environment.GetEnvironmentVariable("shared_secret");
        }
        public object Get(GetNewUserId request)
        {
            return request.SharedSecret == _sharedSecret ? new NewGuid {Guid = Guid.NewGuid()} : new NewGuid();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using JWT;
using JWT.Algorithms;
using JWT.Builder;
using ServiceStack;
using ServiceStack.Auth;
using ServiceStack.Text;
using ServiceStack.Web;

namespace Ponics.Api.Auth
{
    public class JsonWebTokenAuthProvider : AuthProvider, IAuthWithRequest
    {
        private readonly X509Certificate2 _publicKey;
        private const string UnableToParsejwks = "Can Not parse JSON Web Key Set";

        public JsonWebTokenAuthProvider(string authorityDomain)
        {
            var json = $"https://{authorityDomain}/.well-known/jwks.json"
                .GetJsonFromUrl();

            var jwks = JsonSerializer.DeserializeFromString<Jwks>(json);
            var jwk = jwks.keys.FirstOrDefault();
            if (jwk == null)
            {
                throw HttpError.Unauthorized(UnableToParsejwks); 
            }
            _publicKey = new X509Certificate2(Convert.FromBase64String(jwk.x5c.FirstOrDefault()));
        }

        public override bool IsAuthorized(IAuthSession session, IAuthTokens tokens, Authenticate request = null)
        {
            throw new NotImplementedException();
        }

        public override object Authenticate(IServiceBase authService, IAuthSession session, Authenticate request)
        {
            throw new NotImplementedException();
        }

        public void PreAuthenticate(IRequest req, IResponse res)
        {
            throw new NotImplementedException();
        }
    }
}

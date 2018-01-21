using System;
using System.Collections.Generic;
using System.Net;
using JWT.Builder;
using ServiceStack;
using ServiceStack.Auth;
using ServiceStack.Web;

namespace Ponics.Api.Auth
{
    public class JsonWebTokenAuthProvider : AuthProvider, IAuthWithRequest
    {
        public static string Name = "JWT";
        public static string Realm = "/auth/JWT";
        private const string MissingAuthHeader = "Missing Authorization Header";
        private const string InvalidAuthHeader = "Invalid Authorization Header";

        public string SymmetricKey { get; }
        public string Audience { get; }
        public string Issuer { get; set; }

        public JsonWebTokenAuthProvider(string symmetricKey, string audience = null, string issuer = null)
        {
            Provider = Name;
            AuthRealm = Realm;

            SymmetricKey = symmetricKey;
            Audience = audience;
            Issuer = issuer;
        }

        public override bool IsAuthorized(IAuthSession session, IAuthTokens tokens, Authenticate request = null)
        {
            if (request == null)
                return session != null && session.IsAuthenticated && !session.UserAuthName.IsNullOrEmpty();

            if (!LoginMatchesSession(session, request.UserName))
            {
                return false;
            }

            return session != null && session.IsAuthenticated && !session.UserAuthName.IsNullOrEmpty();
        }

        public override object Authenticate(IServiceBase authService, IAuthSession session, Authenticate request)
        {
            var header = request.oauth_token;

            if (header.IsNullOrEmpty())
            {
                throw HttpError.Unauthorized(MissingAuthHeader);
            }

            var headerData = header.Split(' ');

            // if header is missing bearer portion, 401
            if (string.Compare(headerData[0], "Bearer", StringComparison.OrdinalIgnoreCase) != 0)
            {
                throw HttpError.Unauthorized(InvalidAuthHeader);
            }

            try
            {
                // swap - and _ with their Base64 string equivalents
                var secret = this.SymmetricKey.Replace('-', '+').Replace('_', '/');

                var json = new JwtBuilder()
                    .WithSecret(secret)
                    .Issuer(this.Issuer)
                    .MustVerifySignature()
                    .Decode(headerData[1]);

                return OnAuthenticated(authService, session, new AuthTokens(), new Dictionary<string, string>());
            }
            catch (Exception ex)
            {
                throw new HttpError(HttpStatusCode.Unauthorized, ex);
            }

        }

        public void PreAuthenticate(IRequest req, IResponse res)
        {
            var header = req.Headers["Authorization"];
            var authService = req.TryResolve<AuthenticateService>();
            authService.Request = req;

            authService.Post(new Authenticate
            {
                provider = Name,
                oauth_token = header
            });
        }
    }
}

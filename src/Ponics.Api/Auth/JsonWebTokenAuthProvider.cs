using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using ServiceStack;
using ServiceStack.Auth;
using ServiceStack.Host;
using ServiceStack.Text;
using ServiceStack.Web;

namespace Ponics.Api.Auth
{
    public class JsonWebTokenAuthProvider : AuthProvider, IAuthWithRequest
    {
        public const string Name = AuthenticateService.JwtProvider;
        public const string Realm = "/auth/" + AuthenticateService.JwtProvider;


        private readonly TokenValidationParameters _tokenValidationParameters;

        public JsonWebTokenAuthProvider(string authorityDomain, string audience):base(null, Realm, Name)
        {
            var configurationManager = 
                new ConfigurationManager<OpenIdConnectConfiguration>($"{authorityDomain}.well-known/openid-configuration",new OpenIdConnectConfigurationRetriever());
            
            OpenIdConnectConfiguration openIdConfig = null;
            Task.Run(async () =>
                openIdConfig = await configurationManager.GetConfigurationAsync(CancellationToken.None)).Wait();

            _tokenValidationParameters = new TokenValidationParameters
            {
                ValidIssuer = authorityDomain,
                ValidAudiences = new[] {audience},
                IssuerSigningKeys = openIdConfig.SigningKeys
            };
        }

        public override bool IsAuthorized(IAuthSession session, IAuthTokens tokens, Authenticate request = null)
        {
            return session.FromToken && session.IsAuthenticated;
        }

        public override object Authenticate(IServiceBase authService, IAuthSession session, Authenticate request)
        {
            throw new NotImplementedException("JWT Authenticate() should not be called directly");
        }

        public void PreAuthenticate(IRequest req, IResponse res)
        {
#if !DEBUG
            if (!req.IsSecureConnection)
            {
                throw HttpError.Forbidden(ErrorMessages.JwtRequiresSecureConnection);
            }
#endif
            SecurityToken validatedToken;
            var handler = new JwtSecurityTokenHandler();
            try
            {
                var user = handler.ValidateToken(req.GetBearerToken(), _tokenValidationParameters, out validatedToken);

                var session = CreateSessionFromJwtSecurityToken(req, validatedToken as JwtSecurityToken);
                

                var appMetaData = user.Claims.FirstOrDefault(c => c.Type == "https://simpleponics.io/app_meta_data");
                if (appMetaData != null)
                {
                    session.UserAuthId = JsonObject.Parse(appMetaData.Value)["simpleponics_id"];
                }

                req.Items[Keywords.Session] = session;
            }
            catch (Exception ex)
            {
                throw HttpError.Forbidden(ErrorMessages.TokenInvalid);
            }
        }

        public IAuthSession CreateSessionFromJwtSecurityToken(IRequest req, JwtSecurityToken jwtSecurityToken)
        {
            var sessionId = jwtSecurityToken.Header["kid"].ToString();
            var session = SessionFeature.CreateNewSession(req, sessionId);

            session.AuthProvider = Name;
            session.FromToken = true;
            session.IsAuthenticated = true;

            HostContext.AppHost.OnSessionFilter(session, sessionId);
            return session;
        }
    }
}

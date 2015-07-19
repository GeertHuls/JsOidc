using System.Web.Http;
using JavaScriptImplicitClient_Simple;
using Microsoft.Owin;
using Owin;
using Thinktecture.IdentityServer.AccessTokenValidation;

[assembly: OwinStartup(typeof(Startup))]

namespace JavaScriptImplicitClient_Simple
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseIdentityServerBearerTokenAuthentication(new IdentityServerBearerTokenAuthenticationOptions
            {
                Authority = "https://secured.local:449/identityserver/core",
                RequiredScopes = new [] { "api1" }
            });

            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            config.Filters.Add(new AuthorizeAttribute());
            app.UseWebApi(config);
        }
    }
}

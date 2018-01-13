using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.Cookies;
using System.Web.Helpers;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.Google;


[assembly: OwinStartup(typeof(PaymateMVC.App_Start.Startup))]

namespace PaymateMVC.App_Start
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }

        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            // Enable the application to use a cookie to store information for the signed in user
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Security/Login")
            });


            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // App.Secrets is application specific and holds values in CodePasteKeys.json
            // Values are NOT included in repro – auto-created on first load
            //if (!string.IsNullOrEmpty("664040056835-a6d5r4fnnacq0v4v3k6rgo2384coolv5.apps.googleusercontent.com"))
            //{
            app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
            {
                ClientId = "664040056835-a6d5r4fnnacq0v4v3k6rgo2384coolv5.apps.googleusercontent.com",
                ClientSecret = "bBmotrMdAzWWqSqlgcx4tvT4",
                CallbackPath = new PathString("/GoogleLoginCallback")
            });

            //}

            //if (!string.IsNullOrEmpty(App.Secrets.TwitterConsumerKey))
            //{
            //    app.UseTwitterAuthentication(
            //        consumerKey: App.Secrets.TwitterConsumerKey,
            //        consumerSecret: App.Secrets.TwitterConsumerSecret);
            //}

            //if (!string.IsNullOrEmpty(App.Secrets.GitHubClientId))
            //{
            //    app.UseGitHubAuthentication(
            //        clientId: App.Secrets.GitHubClientId,
            //        clientSecret: App.Secrets.GitHubClientSecret);
            //}

            AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimTypes.NameIdentifier;
        }
    }
}

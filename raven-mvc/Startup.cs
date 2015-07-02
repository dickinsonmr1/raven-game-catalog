using System.Web.Http;
using Microsoft.Owin;
using Owin;
using RavenGameCatalog;

// http://www.daniellewis.me.uk/2015/03/23/web-api-with-owin-bootstrap-and-angularjs-from-scratch-part-1/
// http://www.pluralsight.com/courses/tekpub-ravendb

[assembly: OwinStartup(typeof(Startup))]

namespace RavenGameCatalog
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();

            config.Routes.MapHttpRoute("DefaultAPI", "api/{controller}/{id}", new { id = RouteParameter.Optional });

            app.UseWebApi(config);
        }
    }
}
using System;
using System.Data.Entity.Migrations;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Http;
using AbstractorSamples.Web.Persistence.EntityFramework.Contexts;

namespace AbstractorSamples.Web
{
    public class Global : HttpApplication
    {
        public void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            // Registers the Abstractor framework and all application concrete implementations
            AbstractorConfig.Register(GlobalConfiguration.Configuration);

            // Executes the database migrator
            // It's a best practice use it only in development environment, or with extreme caution.
            var applicationMigrator = new DbMigrator(new ApplicationMigrationContextConfiguration());
            applicationMigrator.Update();
        }
    }
}
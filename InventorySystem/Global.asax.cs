using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using Inventory;
using System.Web.Http;

namespace Inventory
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            RouteTable.Routes.MapHttpRoute(
              name: "DefaultApi",
              routeTemplate: "api/{controller}/{Id}",
              defaults: new { ProductId = System.Web.Http.RouteParameter.Optional });
        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown

        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs

        }
    }
}

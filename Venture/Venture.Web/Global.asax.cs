using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using ABC.Venture.Common;

namespace Venture.Web
{
   public class MvcApplication : System.Web.HttpApplication
   {
      protected void Application_Start()
      {
         AreaRegistration.RegisterAllAreas();
         FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
         RouteConfig.RegisterRoutes(RouteTable.Routes);
         BundleConfig.RegisterBundles(BundleTable.Bundles);
      }
      protected void Application_Error(object sender, EventArgs e)
      {
         Exception exception = Server.GetLastError().GetBaseException();
         var log = new Log("application_error");
         log.Error("an unhandled error occurred.", exception);
         Response.Clear();
         Server.ClearError();
         Response.Redirect("/Error/Error");
      }
   }
}

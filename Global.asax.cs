using System;
using System.Collections.Generic;
using System.Configuration;

using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace GYM
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static string ConnectionString = ConfigurationManager.ConnectionStrings["_ConnectionString"].ToString();

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}

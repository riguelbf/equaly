using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DKO.EQualy.UI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Login", action = "index", id = UrlParameter.Optional }
            );

            //routes.MapRoute(
            //    name: "NaoConformidade_default",
            //    url: "NaoConformidade/{controller}/{action}/{id}",
            //    defaults: new { controller = "Login", action = "index", id = UrlParameter.Optional },
            //    namespaces: new[] { "DKO.EQualy.UI.NaoConformidade.Controllers" }  

            //);
        }
    }
}

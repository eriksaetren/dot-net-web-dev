using PlanSimplyByCJ.RouteHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PlanSimplyByCJ
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            /*routes.Add(
                new Route("{controller}/{action}/{id}",
                    new RouteValueDictionary(
                        new { controller = "wedding", action = "home", id = UrlParameter.Optional }
                    ),
                    new HyphenatedRouteHandler()
                ));*/

            /*routes.MapRoute("NoController", "{action}", new { controller = "wedding", action = "home" });*/

            /*routes.MapRoute("Gallery",
               "{controller}/{action}/{albumname}"
               );
            */
            routes.MapRoute(
                "Default", 
                "{controller}/{action}/{albumname}",
                new { controller = "wedding", action = "home", albumname = UrlParameter.Optional}
                );

            //RouteTable.Routes.AppendTrailingSlash = true;
            // RouteTable.Routes.LowercaseUrls = true;
        }


    }
}

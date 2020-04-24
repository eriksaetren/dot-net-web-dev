using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PlanSimplyByCJ.RouteHandler
{
    public class HyphenatedRouteHandler : MvcRouteHandler
    {
        protected override IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            requestContext.RouteData.Values["controller"] =
               requestContext.RouteData.Values["controller"].ToString().ToLower();
            requestContext.RouteData.Values["action"] =
               requestContext.RouteData.Values["action"].ToString().ToLower();
            return base.GetHttpHandler(requestContext);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Sitecore.Diagnostics;
using Sitecore.Pipelines;

namespace Sitecore.SharedSource.CognitiveServices.LaunchDemo.App_Start
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)

        {
            routes.MapRoute(
                name: "CognitiveLaunchDemo", 
                url: "CognitiveLaunchDemo/{controller}/{action}"
            );
        }
    }

    public class LoadRoutes
    {
        public void Process(PipelineArgs args)
        {
            Log.Info("Sitecore is loading Cognitive Launch Demo Routes", this);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
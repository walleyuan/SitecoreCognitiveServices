using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using Sitecore.Pipelines;

namespace SitecoreCognitiveServices.Foundation.SCSDK.App_Start
{
    public class RegisterArea
    {
        public virtual void Process(PipelineArgs args)
        {
            var car = new CognitiveAreaRegistration();

            try
            {
                List<RouteBase> list = RouteTable
                    .Routes
                    .Where(route =>
                    {
                        Route route1 = route as Route;
                        return route1?.Defaults != null && route1.Defaults.ContainsKey("area") 
                            && string.Equals(
                                route1.Defaults["area"].ToString(), 
                                car.AreaName, 
                                StringComparison.Ordinal);
                    })
                    .ToList();

                if (!list.Any())
                {
                    car.RegisterArea(new AreaRegistrationContext(car.AreaName, RouteTable.Routes));
                    return;
                }

                foreach (Route route in list)
                    route.DataTokens["UseNamespaceFallback"] = true;
            }
            catch (Exception ex) { }
        }
    }

    public class CognitiveAreaRegistration : AreaRegistration
    {
        public override string AreaName => "SitecoreCognitiveServices";

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(AreaName, "SitecoreCognitiveServices/{controller}/{action}", new
            {
                area = AreaName
            });
        }
    }
}
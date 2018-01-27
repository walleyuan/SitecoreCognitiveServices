using Microsoft.Extensions.DependencyInjection;
using Sitecore.DependencyInjection;
using System.Web.Mvc;
using SitecoreCognitiveServices.Project.LaunchDemo.Areas.SitecoreCognitiveServices.Controllers;

namespace SitecoreCognitiveServices.Project.LaunchDemo.App_Start
{
    public class IocConfig : IServicesConfigurator
    {
        public void Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient(typeof(CognitiveLaunchController));
        }
    }
}
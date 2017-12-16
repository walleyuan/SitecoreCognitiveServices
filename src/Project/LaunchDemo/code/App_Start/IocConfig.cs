using Microsoft.Extensions.DependencyInjection;
using Sitecore.DependencyInjection;
using SitecoreCognitiveServices.Project.LaunchDemo.Controllers;
using System.Web.Mvc;

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
using Microsoft.Extensions.DependencyInjection;
using Sitecore.DependencyInjection;
using Sitecore.SharedSource.CognitiveServices.LaunchDemo.Controllers;
using System.Web.Mvc;

namespace Sitecore.SharedSource.CognitiveServices.LaunchDemo.App_Start
{
    public class IocConfig : IServicesConfigurator
    {
        public void Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient(typeof(CognitiveLaunchController));
        }
    }
}
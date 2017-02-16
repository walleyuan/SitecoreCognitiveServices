using Microsoft.Extensions.DependencyInjection;
using Sitecore.DependencyInjection;
using Sitecore.Foundation.DependencyInjection;

namespace Sitecore.SharedSource.CognitiveServices.LaunchDemo.Configurator
{
    public class CognitiveLaunchConfigurator : IServicesConfigurator
    {
        public void Configure(IServiceCollection serviceCollection)
        {
            //system
            //serviceCollection.AddTransient<ISomething, Something>();
            
            serviceCollection.AddMvcControllersInCurrentAssembly();
        }
    }
}
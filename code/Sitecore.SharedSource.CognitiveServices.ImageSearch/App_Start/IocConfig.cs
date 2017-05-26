using Microsoft.Extensions.DependencyInjection;
using Sitecore.SharedSource.CognitiveServices.ImageSearch.Models;
using Sitecore.SharedSource.CognitiveServices.ImageSearch.Factories;
using Sitecore.SharedSource.CognitiveServices.ImageSearch.Search;
using Sitecore.SharedSource.CognitiveServices.ImageSearch.Controllers;
using Sitecore.DependencyInjection;
using System.Web.Mvc;

namespace Sitecore.SharedSource.CognitiveServices.ImageSearch.App_Start
{
    public class IocConfig : IServicesConfigurator
    {
        public void Configure(IServiceCollection serviceCollection)
        {
            //factory models
            serviceCollection.AddTransient<ICognitiveImageSearch, CognitiveImageSearch>();
            serviceCollection.AddTransient<ICognitiveImageSearchJsonResult, CognitiveImageSearchJsonResult>();

            //factories
            serviceCollection.AddTransient<ICognitiveImageSearchFactory, CognitiveImageSearchFactory>();
            
            //search
            serviceCollection.AddTransient<ICognitiveImageSearchContext, CognitiveImageSearchContext>();
            serviceCollection.AddTransient<ICognitiveImageSearchResult, CognitiveImageSearchResult>();
            
            serviceCollection.AddTransient(typeof(CognitiveImageSearchController));
        }
    }
}
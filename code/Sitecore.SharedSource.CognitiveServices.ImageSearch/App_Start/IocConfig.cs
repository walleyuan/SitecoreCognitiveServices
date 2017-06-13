using Microsoft.Extensions.DependencyInjection;
using Sitecore.SharedSource.CognitiveServices.ImageSearch.Models;
using Sitecore.SharedSource.CognitiveServices.ImageSearch.Factories;
using Sitecore.SharedSource.CognitiveServices.ImageSearch.Search;
using Sitecore.SharedSource.CognitiveServices.ImageSearch.Controllers;
using Sitecore.DependencyInjection;
using System.Web.Mvc;
using Sitecore.SharedSource.CognitiveServices.ImageSearch.Models.Analysis;
using Sitecore.SharedSource.CognitiveServices.ImageSearch.Models.Utility;
using Sitecore.SharedSource.CognitiveServices.ImageSearch.Services.Search;

namespace Sitecore.SharedSource.CognitiveServices.ImageSearch.App_Start
{
    public class IocConfig : IServicesConfigurator
    {
        public void Configure(IServiceCollection serviceCollection)
        {
            //system
            serviceCollection.AddTransient<IImageSearchSettings, ImageSearchSettings>();

            //factory models
            serviceCollection.AddTransient<ICognitiveImageSearch, CognitiveImageSearch>();
            serviceCollection.AddTransient<ICognitiveImageSearchJsonResult, CognitiveImageSearchJsonResult>();
            serviceCollection.AddTransient<ICognitiveImageAnalysis, CognitiveImageAnalysis>();
            serviceCollection.AddTransient<IImageDescription, ImageDescription>();
            serviceCollection.AddTransient<IReanalyzeAll, ReanalyzeAll>();
            serviceCollection.AddTransient<ISetAltTagsAll, SetAltTagsAll>();

            //factories
            serviceCollection.AddTransient<ICognitiveImageSearchFactory, CognitiveImageSearchFactory>();
            serviceCollection.AddTransient<ICognitiveImageAnalysisFactory, CognitiveImageAnalysisFactory>();
            serviceCollection.AddTransient<IImageDescriptionFactory, ImageDescriptionFactory>();
            serviceCollection.AddTransient<IReanalyzeAllFactory, ReanalyzeAllFactory>();
            serviceCollection.AddTransient<ISetAltTagsAllFactory, SetAltTagsAllFactory>();

            //search
            serviceCollection.AddTransient<ICognitiveImageSearchContext, CognitiveImageSearchContext>();
            serviceCollection.AddTransient<ICognitiveImageSearchResult, CognitiveImageSearchResult>();
            serviceCollection.AddTransient<IImageSearchService, ImageSearchService>();
            serviceCollection.AddTransient<ICognitiveImageSearchContext, CognitiveImageSearchContext>();
            serviceCollection.AddTransient<ICognitiveImageSearchResult, CognitiveImageSearchResult>();

            //controllers
            serviceCollection.AddTransient(typeof(CognitiveImageSearchController));
        }
    }
}
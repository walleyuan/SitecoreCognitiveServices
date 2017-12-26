using Microsoft.Extensions.DependencyInjection;
using SitecoreCognitiveServices.Feature.ImageSearch.Models;
using SitecoreCognitiveServices.Feature.ImageSearch.Factories;
using SitecoreCognitiveServices.Feature.ImageSearch.Search;
using SitecoreCognitiveServices.Feature.ImageSearch.Controllers;
using Sitecore.DependencyInjection;
using System.Web.Mvc;
using SitecoreCognitiveServices.Feature.ImageSearch.Analysis;
using SitecoreCognitiveServices.Feature.ImageSearch.Models.Analysis;
using SitecoreCognitiveServices.Feature.ImageSearch.Models.Utility;

namespace SitecoreCognitiveServices.Feature.ImageSearch.App_Start
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
            serviceCollection.AddTransient<ICognitiveImageSearchResult, CognitiveImageSearchResult>();
            serviceCollection.AddTransient<IImageSearchService, ImageSearchService>();
            
            //analysis
            serviceCollection.AddTransient<IImageAnalysisService, ImageAnalysisService>();

            //controllers
            serviceCollection.AddTransient(typeof(CognitiveImageSearchController));
        }
    }
}
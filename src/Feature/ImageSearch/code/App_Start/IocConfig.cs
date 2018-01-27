using Microsoft.Extensions.DependencyInjection;
using SitecoreCognitiveServices.Feature.ImageSearch.Factories;
using SitecoreCognitiveServices.Feature.ImageSearch.Search;
using Sitecore.DependencyInjection;
using System.Web.Mvc;
using SitecoreCognitiveServices.Feature.ImageSearch.Analysis;
using SitecoreCognitiveServices.Feature.ImageSearch.Areas.SitecoreCognitiveServices.Controllers;
using SitecoreCognitiveServices.Feature.ImageSearch.Areas.SitecoreCognitiveServices.Models;
using SitecoreCognitiveServices.Feature.ImageSearch.Areas.SitecoreCognitiveServices.Models.Analysis;
using SitecoreCognitiveServices.Feature.ImageSearch.Areas.SitecoreCognitiveServices.Models.Setup;
using SitecoreCognitiveServices.Feature.ImageSearch.Areas.SitecoreCognitiveServices.Models.Utility;

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
            serviceCollection.AddTransient<IAnalyzeAll, AnalyzeAll>();
            serviceCollection.AddTransient<ISetAltTagsAll, SetAltTagsAll>();
            serviceCollection.AddTransient<IAnalysisJobResult, AnalysisJobResult>();
            serviceCollection.AddTransient<ISetupInformation, SetupInformation>();

            //factories
            serviceCollection.AddTransient<ICognitiveImageSearchFactory, CognitiveImageSearchFactory>();
            serviceCollection.AddTransient<ICognitiveImageAnalysisFactory, CognitiveImageAnalysisFactory>();
            serviceCollection.AddTransient<IImageDescriptionFactory, ImageDescriptionFactory>();
            serviceCollection.AddTransient<IAnalyzeAllFactory, AnalyzeAllFactory>();
            serviceCollection.AddTransient<ISetAltTagsAllFactory, SetAltTagsAllFactory>();
            serviceCollection.AddTransient<IAnalysisJobResultFactory, AnalysisJobResultFactory>();
            serviceCollection.AddTransient<ISetupInformationFactory, SetupInformationFactory>();

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
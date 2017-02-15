using Microsoft.Extensions.DependencyInjection;
using Sitecore.DependencyInjection;
using Sitecore.Foundation.DependencyInjection;
using Sitecore.SharedSource.CognitiveServices.Factories;
using Sitecore.SharedSource.CognitiveServices.Repositories;
using Sitecore.SharedSource.CognitiveServices.Repositories.Knowledge;
using Sitecore.SharedSource.CognitiveServices.Repositories.Language;
using Sitecore.SharedSource.CognitiveServices.Repositories.Speech;
using Sitecore.SharedSource.CognitiveServices.Repositories.Video;
using Sitecore.SharedSource.CognitiveServices.Repositories.Vision;
using Sitecore.SharedSource.CognitiveServices.Foundation;
using Sitecore.SharedSource.CognitiveServices.Services;
using Sitecore.SharedSource.CognitiveServices.Services.Knowledge;
using Sitecore.SharedSource.CognitiveServices.Services.Language;
using Sitecore.SharedSource.CognitiveServices.Services.Speech;
using Sitecore.SharedSource.CognitiveServices.Services.Video;
using Sitecore.SharedSource.CognitiveServices.Services.Vision;
using Sitecore.SharedSource.CognitiveServices.Search;

namespace Sitecore.SharedSource.CognitiveServices.Configurator
{
    public class CognitiveConfigurator : IServicesConfigurator
    {
        public void Configure(IServiceCollection serviceCollection)
        {
            //system
            serviceCollection.AddSingleton<IApiKeys, ApiKeys>();
            serviceCollection.AddTransient<ISitecoreDataService, SitecoreDataService>();
            serviceCollection.AddTransient<IWebUtilWrapper, WebUtilWrapper>();
            serviceCollection.AddTransient<ISettingsWrapper, SettingsWrapper>();
            serviceCollection.AddTransient<IReflectionUtilWrapper, ReflectionUtilWrapper>();

            //repositories
            serviceCollection.AddTransient<ICognitiveRepositoryContext, CognitiveRepositoryContext>();
            serviceCollection.AddTransient<IEmotionRepository, EmotionRepository>();
            serviceCollection.AddTransient<IEntityLinkingRepository, EntityLinkingRepository>();
            serviceCollection.AddTransient<IFaceRepository, FaceRepository>();
            serviceCollection.AddTransient<ILanguageRepository, LanguageRepository>();
            serviceCollection.AddTransient<ILinguisticRepository, LinguisticRepository>();
            serviceCollection.AddTransient<ISentimentRepository, SentimentRepository>();
            serviceCollection.AddTransient<ISpeakerIdentificationRepository, SpeakerIdentificationRepository>();
            serviceCollection.AddTransient<ISpeakerVerificationRepository, SpeakerVerificationRepository>();
            serviceCollection.AddTransient<IVideoRepository, VideoRepository>();
            serviceCollection.AddTransient<IVisionRepository, VisionRepository>();

            //services
            serviceCollection.AddTransient<ICognitiveServiceContext, CognitiveServiceContext>();
            serviceCollection.AddTransient<IEmotionService, EmotionService>();
            serviceCollection.AddTransient<IEntityLinkingService, EntityLinkingService>();
            serviceCollection.AddTransient<IFaceService, FaceService>();
            serviceCollection.AddTransient<ILanguageService, LanguageService>();
            serviceCollection.AddTransient<ILinguisticService, LinguisticService>();
            serviceCollection.AddTransient<ISentimentService, SentimentService>();
            serviceCollection.AddTransient<ISpeakerIdentificationService, SpeakerIdentificationService>();
            serviceCollection.AddTransient<ISpeakerVerificationService, SpeakerVerificationService>();
            serviceCollection.AddTransient<IVideoService, VideoService>();
            serviceCollection.AddTransient<IVisionService, VisionService>();
            
            //factories
            serviceCollection.AddTransient<ICognitiveImageAnalysisFactory, CognitiveImageAnalysisFactory>();
            serviceCollection.AddTransient<ICognitiveTextAnalysisFactory, CognitiveTextAnalysisFactory>();
            serviceCollection.AddTransient<IImageDescriptionFactory, ImageDescriptionFactory>();
            serviceCollection.AddTransient<IReanalyzeAllFactory, ReanalyzeAllFactory>();
            serviceCollection.AddTransient<ISetAltTagsAllFactory, SetAltTagsAllFactory>();
            serviceCollection.AddTransient<ICognitiveMediaSearchFactory, CognitiveMediaSearchFactory>();

            //search
            serviceCollection.AddTransient<ICognitiveSearchContext, CognitiveSearchContext>();
            serviceCollection.AddTransient<ICognitiveSearchResult, CognitiveSearchResult>();
            
            serviceCollection.AddMvcControllersInCurrentAssembly();
        }
    }
}
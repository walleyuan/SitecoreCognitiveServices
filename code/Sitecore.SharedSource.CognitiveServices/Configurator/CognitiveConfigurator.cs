using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using Microsoft.Extensions.DependencyInjection;
using Sitecore.DependencyInjection;
using Sitecore.Foundation.DependencyInjection;
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

namespace Sitecore.SharedSource.CognitiveServices.Configurator
{
    public class CognitiveConfigurator : IServicesConfigurator
    {
        public void Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IApiKeys, ApiKeys>();
            serviceCollection.AddSingleton<ICognitiveRepositoryContext, CognitiveRepositoryContext>();
            serviceCollection.AddSingleton<IEmotionRepository, EmotionRepository>();
            serviceCollection.AddSingleton<IEntityLinkingRepository, EntityLinkingRepository>();
            serviceCollection.AddSingleton<IFaceRepository, FaceRepository>();
            serviceCollection.AddSingleton<ILanguageRepository, LanguageRepository>();
            serviceCollection.AddSingleton<ISentimentRepository, SentimentRepository>();
            serviceCollection.AddSingleton<ISpeakerIdentificationRepository, SpeakerIdentificationRepository>();
            serviceCollection.AddSingleton<ISpeakerVerificationRepository, SpeakerVerificationRepository>();
            serviceCollection.AddSingleton<IVideoRepository, VideoRepository>();
            serviceCollection.AddSingleton<IVisionRepository, VisionRepository>();
            serviceCollection.AddSingleton<IWebUtilWrapper, WebUtilWrapper>();

            serviceCollection.AddSingleton<IApiService, ApiService>();
            serviceCollection.AddSingleton<ICognitiveServiceContext, CognitiveServiceContext>();
            serviceCollection.AddSingleton<IEmotionService, EmotionService>();
            serviceCollection.AddSingleton<IEntityLinkingService, EntityLinkingService>();
            serviceCollection.AddSingleton<IFaceService, FaceService>();
            serviceCollection.AddSingleton<ILanguageService, LanguageService>();
            serviceCollection.AddSingleton<ISentimentService, SentimentService>();
            serviceCollection.AddSingleton<ISpeakerIdentificationService, SpeakerIdentificationService>();
            serviceCollection.AddSingleton<ISpeakerVerificationService, SpeakerVerificationService>();
            serviceCollection.AddSingleton<IVideoService, VideoService>();
            serviceCollection.AddSingleton<IVisionService, VisionService>();

            serviceCollection.AddMvcControllersInCurrentAssembly();
        }
    }
}
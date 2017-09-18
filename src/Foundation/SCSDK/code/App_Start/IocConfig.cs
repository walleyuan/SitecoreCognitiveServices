using Microsoft.Extensions.DependencyInjection;
using SitecoreCognitiveServices.Foundation.MSSDK;
using SitecoreCognitiveServices.Foundation.MSSDK.CSV;
using SitecoreCognitiveServices.Foundation.MSSDK.Repositories;
using SitecoreCognitiveServices.Foundation.MSSDK.Repositories.Bing;
using SitecoreCognitiveServices.Foundation.MSSDK.Repositories.Knowledge;
using SitecoreCognitiveServices.Foundation.MSSDK.Repositories.Language;
using SitecoreCognitiveServices.Foundation.MSSDK.Repositories.Speech;
using SitecoreCognitiveServices.Foundation.MSSDK.Repositories.Vision;
using Sitecore.DependencyInjection;
using SitecoreCognitiveServices.Foundation.SCSDK.Repositories;
using SitecoreCognitiveServices.Foundation.SCSDK.Services.Knowledge;
using SitecoreCognitiveServices.Foundation.SCSDK.Services.Language;
using SitecoreCognitiveServices.Foundation.SCSDK.Services.Speech;
using SitecoreCognitiveServices.Foundation.SCSDK.Services.Vision;
using SitecoreCognitiveServices.Foundation.SCSDK.Services.Bing;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;

namespace SitecoreCognitiveServices.Foundation.SCSDK.App_Start
{
    public class IocConfig : IServicesConfigurator
    {
        public void Configure(IServiceCollection serviceCollection)
        {
            //system
            serviceCollection.AddSingleton<IApplicationSettings, ApplicationSettings>();
            serviceCollection.AddSingleton<IApiKeys, ApiKeys>();
            serviceCollection.AddTransient<IRepositoryClient, RepositoryClient>();
            serviceCollection.AddTransient<ICSVParser, CSVParser>();

            //sitecore wrappers
            serviceCollection.AddTransient<ISitecoreDataWrapper, SitecoreDataWrapper>();
            serviceCollection.AddTransient<IWebUtilWrapper, WebUtilWrapper>();
            serviceCollection.AddTransient<ILogWrapper, LogWrapper>();
            serviceCollection.AddTransient<ITextTranslatorWrapper, TextTranslatorWrapper>();
            serviceCollection.AddTransient<IPublishWrapper, PublishWrapper>();
            serviceCollection.AddTransient<IAuthenticationWrapper, AuthenticationWrapper>();
            serviceCollection.AddTransient<IContentSearchWrapper, ContentSearchWrapper>();

            //repositories
            serviceCollection.AddTransient<IEmotionRepository, EmotionRepository>();
            serviceCollection.AddTransient<IEntityLinkingRepository, EntityLinkingRepository>();
            serviceCollection.AddTransient<IFaceRepository, FaceRepository>();
            serviceCollection.AddTransient<ILinguisticRepository, LinguisticRepository>();
            serviceCollection.AddTransient<ITextAnalyticsRepository, TextAnalyticsRepository>();
            serviceCollection.AddTransient<ISpeakerIdentificationRepository, SpeakerIdentificationRepository>();
            serviceCollection.AddTransient<ISpeakerVerificationRepository, SpeakerVerificationRepository>();
            serviceCollection.AddTransient<IVideoRepository, VideoRepository>();
            serviceCollection.AddTransient<IVisionRepository, VisionRepository>();
            serviceCollection.AddTransient<IAutoSuggestRepository, AutoSuggestRepository>();
            serviceCollection.AddTransient<IImageSearchRepository, ImageSearchRepository>();
            serviceCollection.AddTransient<ISpellCheckRepository, SpellCheckRepository>();
            serviceCollection.AddTransient<IWebSearchRepository, WebSearchRepository>();
            serviceCollection.AddTransient<INewsSearchRepository, NewsSearchRepository>();
            serviceCollection.AddTransient<IVideoSearchRepository, VideoSearchRepository>();
            serviceCollection.AddTransient<IAcademicSearchRepository, AcademicSearchRepository>();
            serviceCollection.AddTransient<IRecommendationsRepository, RecommendationsRepository>();
            serviceCollection.AddTransient<IContentModeratorRepository, ContentModeratorRepository>();
            serviceCollection.AddTransient<IWebLanguageModelRepository, WebLanguageModelRepository>();
            serviceCollection.AddTransient<ILuisRepository, LuisRepository>();
            serviceCollection.AddTransient<ISpeechRepository, SpeechRepository>();
            serviceCollection.AddTransient<IQnAMakerRepository, QnAMakerRepository>();

            //services
            serviceCollection.AddTransient<IEmotionService, EmotionService>();
            serviceCollection.AddTransient<IEntityLinkingService, EntityLinkingService>();
            serviceCollection.AddTransient<IFaceService, FaceService>();
            serviceCollection.AddTransient<ILinguisticService, LinguisticService>();
            serviceCollection.AddTransient<ITextAnalyticsService, TextAnalyticsService>();
            serviceCollection.AddTransient<ISpeakerIdentificationService, SpeakerIdentificationService>();
            serviceCollection.AddTransient<ISpeakerVerificationService, SpeakerVerificationService>();
            serviceCollection.AddTransient<IVideoService, VideoService>();
            serviceCollection.AddTransient<IVisionService, VisionService>();
            serviceCollection.AddTransient<IAutoSuggestService, AutoSuggestService>();
            serviceCollection.AddTransient<IImageSearchService, ImageSearchService>();
            serviceCollection.AddTransient<ISpellCheckService, SpellCheckService>();
            serviceCollection.AddTransient<IWebSearchService, WebSearchService>();
            serviceCollection.AddTransient<INewsSearchService, NewsSearchService>();
            serviceCollection.AddTransient<IVideoSearchService, VideoSearchService>();
            serviceCollection.AddTransient<IAcademicSearchService, AcademicSearchService>();
            serviceCollection.AddTransient<IRecommendationsService, RecommendationsService>();
            serviceCollection.AddTransient<IContentModeratorService, ContentModeratorService>();
            serviceCollection.AddTransient<IWebLanguageModelService, WebLanguageModelService>();
            serviceCollection.AddTransient<ILuisService, LuisService>();
            serviceCollection.AddTransient<ISpeechService, SpeechService>();
            serviceCollection.AddTransient<IQnAMakerService, QnAMakerService>();
        }
    }
}
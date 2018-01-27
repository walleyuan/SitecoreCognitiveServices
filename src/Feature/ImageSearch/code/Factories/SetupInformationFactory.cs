using System;
using Microsoft.Extensions.DependencyInjection;
using SitecoreCognitiveServices.Feature.ImageSearch.Areas.SitecoreCognitiveServices.Models.Setup;
using SitecoreCognitiveServices.Foundation.MSSDK;

namespace SitecoreCognitiveServices.Feature.ImageSearch.Factories
{
    public class SetupInformationFactory : ISetupInformationFactory
    {
        protected readonly IServiceProvider Provider;
        protected readonly IMicrosoftCognitiveServicesApiKeys ApiKeys;

        public SetupInformationFactory(IServiceProvider provider, IMicrosoftCognitiveServicesApiKeys apiKeys)
        {
            Provider = provider;
            ApiKeys = apiKeys;
        }

        public virtual ISetupInformation Create()
        {
            var obj = Provider.GetService<ISetupInformation>();

            obj.FaceApiKey = ApiKeys.Face;
            obj.EmotionApiKey = ApiKeys.Emotion;
            obj.TextAnalyticsApiKey = ApiKeys.TextAnalytics;
            obj.ComputerVisionApiKey = ApiKeys.ComputerVision;

            return obj;
        }
    }
}
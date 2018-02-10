using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Extensions.DependencyInjection;
using SitecoreCognitiveServices.Feature.OleChat.Areas.SitecoreCognitiveServices.Models;
using SitecoreCognitiveServices.Foundation.MSSDK;

namespace SitecoreCognitiveServices.Feature.OleChat.Factories
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

            //obj.LuisApiKey = ApiKeys.Face;
            //obj.LuisApiEndpoint = ApiKeys.FaceEndpoint;
            //obj.EmotionApiKey = ApiKeys.Emotion;
            //obj.EmotionApiEndpoint = ApiKeys.EmotionEndpoint;

            return obj;
        }
    }
}
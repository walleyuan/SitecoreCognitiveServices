using System;
using Microsoft.Extensions.DependencyInjection;
using SitecoreCognitiveServices.Feature.OleChat.Intents;

namespace SitecoreCognitiveServices.Feature.OleChat.Factories {
    
    public class PublishIntentFactory : IIntentFactory<IPublishIntent> {
        
        protected readonly IServiceProvider Provider;

        public PublishIntentFactory(IServiceProvider provider)
        {
            Provider = provider;
        }

        public virtual IPublishIntent Create() {
            return Provider.GetService<IPublishIntent>();
        }
    }
}
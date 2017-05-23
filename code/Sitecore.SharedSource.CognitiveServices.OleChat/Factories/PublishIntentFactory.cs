using System;
using Microsoft.Extensions.DependencyInjection;
using Sitecore.SharedSource.CognitiveServices.OleChat.Intents;

namespace Sitecore.SharedSource.CognitiveServices.OleChat.Factories {
    
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
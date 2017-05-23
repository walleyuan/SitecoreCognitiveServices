using System;
using Microsoft.Extensions.DependencyInjection;
using Sitecore.SharedSource.CognitiveServices.OleChat.Intents;

namespace Sitecore.SharedSource.CognitiveServices.OleChat.Factories {
    
    public class DefaultIntentFactory : IIntentFactory<IDefaultIntent> {
        
        protected readonly IServiceProvider Provider;

        public DefaultIntentFactory(IServiceProvider provider)
        {
            Provider = provider;
        }

        public virtual IDefaultIntent Create() {
            return Provider.GetService<IDefaultIntent>();
        }
    }
}
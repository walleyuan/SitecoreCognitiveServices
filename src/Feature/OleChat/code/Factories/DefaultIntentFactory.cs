using System;
using Microsoft.Extensions.DependencyInjection;
using SitecoreCognitiveServices.Feature.OleChat.Intents;

namespace SitecoreCognitiveServices.Feature.OleChat.Factories {
    
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
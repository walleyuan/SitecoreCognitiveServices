using System;
using Microsoft.Extensions.DependencyInjection;
using SitecoreCognitiveServices.Feature.OleChat.Intents;

namespace SitecoreCognitiveServices.Feature.OleChat.Factories {
    
    public class VersionIntentFactory : IIntentFactory<IVersionIntent> {
        
        protected readonly IServiceProvider Provider;

        public VersionIntentFactory(IServiceProvider provider)
        {
            Provider = provider;
        }

        public virtual IVersionIntent Create() {
            return Provider.GetService<IVersionIntent>();
        }
    }
}
using System;
using Microsoft.Extensions.DependencyInjection;
using Sitecore.SharedSource.CognitiveServices.OleChat.Intents;

namespace Sitecore.SharedSource.CognitiveServices.OleChat.Factories {
    
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
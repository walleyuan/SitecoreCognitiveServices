using System;
using Microsoft.Extensions.DependencyInjection;
using Sitecore.SharedSource.CognitiveServices.Ole.Intents;

namespace Sitecore.SharedSource.CognitiveServices.Factories.Intents {
    public class VersionIntentFactory : IVersionIntentFactory {
        
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
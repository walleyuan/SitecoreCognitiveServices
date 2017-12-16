using System;
using Microsoft.Extensions.DependencyInjection;
using SitecoreCognitiveServices.Feature.OleChat.Intents;

namespace SitecoreCognitiveServices.Feature.OleChat.Factories {
    
    public class LockedItemCountIntentFactory : IIntentFactory<ILockedItemCountIntent> {
        
        protected readonly IServiceProvider Provider;

        public LockedItemCountIntentFactory(IServiceProvider provider)
        {
            Provider = provider;
        }

        public virtual ILockedItemCountIntent Create() {
            return Provider.GetService<ILockedItemCountIntent>();
        }
    }
}
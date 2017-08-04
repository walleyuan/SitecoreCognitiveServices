using System;
using Microsoft.Extensions.DependencyInjection;
using Sitecore.SharedSource.CognitiveServices.OleChat.Intents;

namespace Sitecore.SharedSource.CognitiveServices.OleChat.Factories {
    
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
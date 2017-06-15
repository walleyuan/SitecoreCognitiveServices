using System;
using Microsoft.Extensions.DependencyInjection;
using Sitecore.SharedSource.CognitiveServices.OleChat.Intents;

namespace Sitecore.SharedSource.CognitiveServices.OleChat.Factories {
    
    public class UnlockItemsIntentFactory : IIntentFactory<IUnlockItemsIntent> {
        
        protected readonly IServiceProvider Provider;

        public UnlockItemsIntentFactory(IServiceProvider provider)
        {
            Provider = provider;
        }

        public virtual IUnlockItemsIntent Create() {
            return Provider.GetService<IUnlockItemsIntent>();
        }
    }
}
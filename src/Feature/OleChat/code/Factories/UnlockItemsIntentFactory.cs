using System;
using Microsoft.Extensions.DependencyInjection;
using SitecoreCognitiveServices.Feature.OleChat.Intents;

namespace SitecoreCognitiveServices.Feature.OleChat.Factories {
    
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
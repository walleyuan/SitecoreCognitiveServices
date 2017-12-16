using System;
using Microsoft.Extensions.DependencyInjection;
using SitecoreCognitiveServices.Feature.OleChat.Intents;

namespace SitecoreCognitiveServices.Feature.OleChat.Factories {
    
    public class KickUserIntentFactory : IIntentFactory<IKickUserIntent> {
        
        protected readonly IServiceProvider Provider;

        public KickUserIntentFactory(IServiceProvider provider)
        {
            Provider = provider;
        }

        public virtual IKickUserIntent Create() {
            return Provider.GetService<IKickUserIntent>();
        }
    }
}
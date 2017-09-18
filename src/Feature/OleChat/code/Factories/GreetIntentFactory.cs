using System;
using Microsoft.Extensions.DependencyInjection;
using SitecoreCognitiveServices.Feature.OleChat.Intents;

namespace SitecoreCognitiveServices.Feature.OleChat.Factories {
    
    public class GreetIntentFactory : IIntentFactory<IGreetIntent> {
        
        protected readonly IServiceProvider Provider;

        public GreetIntentFactory(IServiceProvider provider)
        {
            Provider = provider;
        }

        public virtual IGreetIntent Create() {
            return Provider.GetService<IGreetIntent>();
        }
    }
}
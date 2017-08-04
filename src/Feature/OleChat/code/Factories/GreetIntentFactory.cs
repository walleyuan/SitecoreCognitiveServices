using System;
using Microsoft.Extensions.DependencyInjection;
using Sitecore.SharedSource.CognitiveServices.OleChat.Intents;

namespace Sitecore.SharedSource.CognitiveServices.OleChat.Factories {
    
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
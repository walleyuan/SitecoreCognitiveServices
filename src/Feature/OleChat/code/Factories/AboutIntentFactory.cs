using System;
using Microsoft.Extensions.DependencyInjection;
using SitecoreCognitiveServices.Feature.OleChat.Intents;

namespace SitecoreCognitiveServices.Feature.OleChat.Factories {
   
    public class AboutIntentFactory : IIntentFactory<IAboutIntent> {
        
        protected readonly IServiceProvider Provider;

        public AboutIntentFactory(IServiceProvider provider)
        {
            Provider = provider;
        }

        public virtual IAboutIntent Create() {
            return Provider.GetService<IAboutIntent>();
        }
    }
}
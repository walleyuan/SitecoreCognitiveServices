using System;
using Microsoft.Extensions.DependencyInjection;
using SitecoreCognitiveServices.Feature.OleChat.Intents;

namespace SitecoreCognitiveServices.Feature.OleChat.Factories {
   
    public class LogoutIntentFactory : IIntentFactory<ILogoutIntent> {
        
        protected readonly IServiceProvider Provider;

        public LogoutIntentFactory(IServiceProvider provider)
        {
            Provider = provider;
        }

        public virtual ILogoutIntent Create() {
            return Provider.GetService<ILogoutIntent>();
        }
    }
}
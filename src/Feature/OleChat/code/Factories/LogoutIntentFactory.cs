using System;
using Microsoft.Extensions.DependencyInjection;
using Sitecore.SharedSource.CognitiveServices.OleChat.Intents;

namespace Sitecore.SharedSource.CognitiveServices.OleChat.Factories {
   
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
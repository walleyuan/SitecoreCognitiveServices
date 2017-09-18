using System;
using Microsoft.Extensions.DependencyInjection;
using SitecoreCognitiveServices.Feature.OleChat.Intents;

namespace SitecoreCognitiveServices.Feature.OleChat.Factories {
    
    public class LoggedInUsersIntentFactory : IIntentFactory<ILoggedInUsersIntent> {
        
        protected readonly IServiceProvider Provider;

        public LoggedInUsersIntentFactory(IServiceProvider provider)
        {
            Provider = provider;
        }

        public virtual ILoggedInUsersIntent Create() {
            return Provider.GetService<ILoggedInUsersIntent>();
        }
    }
}
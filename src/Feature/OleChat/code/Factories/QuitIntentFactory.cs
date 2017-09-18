using System;
using Microsoft.Extensions.DependencyInjection;
using SitecoreCognitiveServices.Feature.OleChat.Intents;

namespace SitecoreCognitiveServices.Feature.OleChat.Factories
{
    public class QuitIntentFactory : IIntentFactory<IQuitIntent>
    {

        protected readonly IServiceProvider Provider;

        public QuitIntentFactory(IServiceProvider provider)
        {
            Provider = provider;
        }

        public virtual IQuitIntent Create()
        {
            return Provider.GetService<IQuitIntent>();
        }
    }
}
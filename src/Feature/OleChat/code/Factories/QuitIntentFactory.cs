using System;
using Microsoft.Extensions.DependencyInjection;
using Sitecore.SharedSource.CognitiveServices.OleChat.Intents;

namespace Sitecore.SharedSource.CognitiveServices.OleChat.Factories
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
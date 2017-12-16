using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Extensions.DependencyInjection;
using SitecoreCognitiveServices.Feature.OleChat.Intents;

namespace SitecoreCognitiveServices.Feature.OleChat.Factories
{
    public class RebuildIndexIntentFactory : IIntentFactory<IRebuildIndexIntent>
    {
        protected readonly IServiceProvider Provider;

        public RebuildIndexIntentFactory(IServiceProvider provider)
        {
            Provider = provider;
        }

        public virtual IRebuildIndexIntent Create()
        {
            return Provider.GetService<IRebuildIndexIntent>();
        }
    }
}
using SitecoreCognitiveServices.Feature.OleChat.Intents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Extensions.DependencyInjection;

namespace SitecoreCognitiveServices.Feature.OleChat.Factories
{
    public class FrustratedUserIntentFactory : IIntentFactory<IFrustratedUserIntent>
    {

        protected readonly IServiceProvider Provider;

        public FrustratedUserIntentFactory(IServiceProvider provider)
        {
            Provider = provider;
        }

        public virtual IFrustratedUserIntent Create()
        {
            return Provider.GetService<IFrustratedUserIntent>();
        }
    }
}
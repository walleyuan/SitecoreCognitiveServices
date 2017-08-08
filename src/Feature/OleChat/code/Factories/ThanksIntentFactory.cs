using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Extensions.DependencyInjection;
using Sitecore.SharedSource.CognitiveServices.OleChat.Intents;

namespace Sitecore.SharedSource.CognitiveServices.OleChat.Factories
{
    public class ThanksIntentFactory : IIntentFactory<IThanksIntent>
    {

        protected readonly IServiceProvider Provider;

        public ThanksIntentFactory(IServiceProvider provider)
        {
            Provider = provider;
        }

        public virtual IThanksIntent Create()
        {
            return Provider.GetService<IThanksIntent>();
        }
    }
}
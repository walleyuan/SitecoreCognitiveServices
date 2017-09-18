using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SitecoreCognitiveServices.Feature.OleChat.Dialog;
using Microsoft.Extensions.DependencyInjection;
using MicrosoftCognitiveServices.Foundation.MSSDK.Models.Language.Luis;
using SitecoreCognitiveServices.Feature.OleChat.Intents;

namespace SitecoreCognitiveServices.Feature.OleChat.Factories
{
    public class ConversationFactory : IConversationFactory
    {
        protected readonly IServiceProvider Provider;

        public ConversationFactory(IServiceProvider provider)
        {
            Provider = provider;
        }

        public virtual IConversation Create(LuisResult result, IIntent intent)
        {
            var convo = Provider.GetService<IConversation>();
            convo.Result = result;
            convo.Intent = intent;
            convo.Context = new Dictionary<string, string>();
            convo.Data = new Dictionary<string, object>();

            return convo;
        }
    }
}
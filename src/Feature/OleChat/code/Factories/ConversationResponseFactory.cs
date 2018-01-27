using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SitecoreCognitiveServices.Feature.OleChat.Areas.SitecoreCognitiveServices.Models;
using SitecoreCognitiveServices.Feature.OleChat.Models;

namespace SitecoreCognitiveServices.Feature.OleChat.Factories
{
    public interface IConversationResponseFactory
    {
        ConversationResponse Create(string message);
        ConversationResponse Create(string message, IntentOptionSet options);
        ConversationResponse Create(string message, string action);
    }

    public class ConversationResponseFactory : IConversationResponseFactory
    {
        protected readonly IIntentOptionSetFactory IntentOptionSetFactory;

        public ConversationResponseFactory(IIntentOptionSetFactory optionSetFactory)
        {
            IntentOptionSetFactory = optionSetFactory;
        }

        public ConversationResponse Create(string message)
        {
            return new ConversationResponse {
                Message = message,
                Action = string.Empty,
                OptionsSet = IntentOptionSetFactory.Create(IntentOptionType.None)
            };
        }

        public ConversationResponse Create(string message, IntentOptionSet options)
        {
            var response = Create(message);
            response.OptionsSet = options;

            return response;
        }

        public ConversationResponse Create(string message, string action)
        {
            var response = Create(message);
            response.Action = action;
            response.OptionsSet = IntentOptionSetFactory.Create(IntentOptionType.None);

            return response;
        }
    }
}
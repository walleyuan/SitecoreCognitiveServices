using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SitecoreCognitiveServices.Feature.OleChat.Models;

namespace SitecoreCognitiveServices.Feature.OleChat.Factories
{
    public interface IConversationResponseFactory
    {
        ConversationResponse Create(string message);
        ConversationResponse Create(string message, Dictionary<string, string> options);
        ConversationResponse Create(string message, string action);
    }

    public class ConversationResponseFactory : IConversationResponseFactory
    {
        public ConversationResponse Create(string message)
        {
            return new ConversationResponse {Message = message};
        }

        public ConversationResponse Create(string message, Dictionary<string, string> options)
        {
            return new ConversationResponse
            {
                Message = message,
                Options = options
            };
        }

        public ConversationResponse Create(string message, string action) {
            return new ConversationResponse
            {
                Message = message,
                Action = action
            };
        }
    }
}
using System;
using System.Collections.Generic;
using SitecoreCognitiveServices.Feature.OleChat.Models;

namespace SitecoreCognitiveServices.Feature.OleChat.Intents
{
    public interface IIntentProvider
    {
        Dictionary<string, IIntent> GetAllIntents(Guid appId);

        IIntent GetIntent(Guid appId, string intentName);

        ConversationResponse GetDefaultResponse(Guid appId);
    }
}
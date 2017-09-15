using System;
using System.Collections.Generic;
using Sitecore.SharedSource.CognitiveServices.OleChat.Models;

namespace Sitecore.SharedSource.CognitiveServices.OleChat.Intents
{
    public interface IIntentProvider
    {
        Dictionary<string, IIntent> GetAllIntents(Guid appId);

        IIntent GetIntent(Guid appId, string intentName);

        ConversationResponse GetDefaultResponse(Guid appId);
    }
}
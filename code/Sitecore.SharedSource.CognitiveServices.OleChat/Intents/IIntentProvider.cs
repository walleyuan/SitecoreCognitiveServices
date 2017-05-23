using System;
using System.Collections.Generic;

namespace Sitecore.SharedSource.CognitiveServices.OleChat.Intents
{
    public interface IIntentProvider
    {
        Dictionary<string, IIntent> GetAllIntents(Guid appId);

        IIntent GetIntent(Guid appId, string intentName);

        string GetDefaultResponse(Guid appId);
    }
}
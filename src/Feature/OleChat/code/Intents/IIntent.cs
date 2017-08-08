using System;
using System.Collections.Generic;
using Microsoft.SharedSource.CognitiveServices.Models.Language.Luis;
using Sitecore.SharedSource.CognitiveServices.OleChat.Dialog;
using Sitecore.SharedSource.CognitiveServices.OleChat.Models;

namespace Sitecore.SharedSource.CognitiveServices.OleChat.Intents {
    public interface IIntent {
        Guid ApplicationId { get; }
        string Name { get; }
        string Description { get; }
        List<ConversationParameter> RequiredParameters { get; }
        string Respond(LuisResult result, ItemContextParameters parameters, IConversation conversation);
        string ProcessResponse(LuisResult result, ItemContextParameters parameters, IConversation conversation);
    }
}
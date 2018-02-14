using System;
using System.Collections.Generic;
using SitecoreCognitiveServices.Feature.OleChat.Areas.SitecoreCognitiveServices.Models;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Language.Luis;
using SitecoreCognitiveServices.Feature.OleChat.Dialog;
using SitecoreCognitiveServices.Feature.OleChat.Models;

namespace SitecoreCognitiveServices.Feature.OleChat.Intents {
    public interface IOleIntent {
        Guid ApplicationId { get; }
        string Name { get; }
        string Description { get; }
        bool RequiresConfirmation { get; }
        List<ConversationParameter> RequiredParameters { get; }
        ConversationResponse Respond(LuisResult result, ItemContextParameters parameters, IConversation conversation);
    }
}
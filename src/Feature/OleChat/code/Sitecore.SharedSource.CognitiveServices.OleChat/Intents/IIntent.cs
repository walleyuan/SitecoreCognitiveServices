using System;
using Microsoft.SharedSource.CognitiveServices.Models.Language.Luis;
using Sitecore.SharedSource.CognitiveServices.OleChat.Models;

namespace Sitecore.SharedSource.CognitiveServices.OleChat.Intents {
    public interface IIntent {
        Guid ApplicationId { get; }
        string Name { get; }
        string Description { get; }
        string Respond(LuisResult result, ItemContextParameters parameters);
    }
}
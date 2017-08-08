using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.SharedSource.CognitiveServices.Models.Language.Luis;
using Sitecore.SharedSource.CognitiveServices.OleChat.Intents;

namespace Sitecore.SharedSource.CognitiveServices.OleChat.Dialog
{
    public interface IConversation
    {
        bool IsEnded { get; set; }
        IIntent Intent { get; set; }
        LuisResult Result { get; set; }
        Dictionary<string, string> Context { get; set; }
        Dictionary<string, object> Data { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Language.Luis;
using SitecoreCognitiveServices.Feature.OleChat.Intents;

namespace SitecoreCognitiveServices.Feature.OleChat.Dialog
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
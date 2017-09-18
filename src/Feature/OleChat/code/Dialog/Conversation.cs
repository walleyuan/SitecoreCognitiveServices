using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MicrosoftCognitiveServices.Foundation.MSSDK.Models.Language.Luis;
using SitecoreCognitiveServices.Feature.OleChat.Intents;

namespace SitecoreCognitiveServices.Feature.OleChat.Dialog
{
    public class Conversation : IConversation
    {
        public virtual bool IsEnded { get; set; }
        public virtual IIntent Intent { get; set; }
        public virtual LuisResult Result { get; set; }
        public virtual Dictionary<string, string> Context { get; set; }
        public virtual Dictionary<string, object> Data { get; set; }
    }
}
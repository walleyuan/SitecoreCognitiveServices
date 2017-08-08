using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.SharedSource.CognitiveServices.Models.Language.Luis;
using Sitecore.SharedSource.CognitiveServices.OleChat.Intents;

namespace Sitecore.SharedSource.CognitiveServices.OleChat.Dialog
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
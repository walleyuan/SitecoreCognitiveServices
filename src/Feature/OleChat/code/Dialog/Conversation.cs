using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Language.Luis;
using SitecoreCognitiveServices.Feature.OleChat.Intents;

namespace SitecoreCognitiveServices.Feature.OleChat.Dialog
{
    public class Conversation : IConversation
    {
        public virtual bool IsEnded { get; set; }
        public virtual bool IsConfirmed { get; set; }
        public virtual IOleIntent Intent { get; set; }
        public virtual LuisResult Result { get; set; }
        /// <summary>
        /// The stored parameter values provided by the user input (ie: 'web')
        /// </summary>
        public virtual Dictionary<string, string> Context { get; set; }
        /// <summary>
        /// the stored parameter objects converted from the user input (ie: the web database object)
        /// </summary>
        public virtual Dictionary<string, object> Data { get; set; }
    }
}
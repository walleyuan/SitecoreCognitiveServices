using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SitecoreCognitiveServices.Feature.OleChat.Areas.SitecoreCognitiveServices.Models;
using SitecoreCognitiveServices.Feature.OleChat.Models;

namespace SitecoreCognitiveServices.Feature.OleChat.Dialog
{
    public class ConversationParameter
    {
        public ConversationParameter(string name, string message, Func<string, ItemContextParameters, IConversation, object> paramGetter, Func<ItemContextParameters, IntentOptionSet> options)
        {
            ParamName = name;
            ParamMessage = message;
            ParamGetter = paramGetter;
            ParamOptions = options;
        }

        public string ParamName { get; set; }
        public string ParamMessage { get; set; }
        public Func<string, ItemContextParameters, IConversation, object> ParamGetter { get; set; }
        public Func<ItemContextParameters, IntentOptionSet> ParamOptions { get; set; }
    }
}
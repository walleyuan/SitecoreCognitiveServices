using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SitecoreCognitiveServices.Feature.OleChat.Models;

namespace SitecoreCognitiveServices.Feature.OleChat.Dialog
{
    public class ConversationParameter
    {
        public ConversationParameter(string name, string message, Func<string, ItemContextParameters, IConversation, bool> validation, Func<ItemContextParameters, IntentOptionSet> options)
        {
            ParamName = name;
            ParamMessage = message;
            ParamValidation = validation;
            ParamOptions = options;
        }

        public string ParamName { get; set; }
        public string ParamMessage { get; set; }
        public Func<string, ItemContextParameters, IConversation, bool> ParamValidation { get; set; }
        public Func<ItemContextParameters, IntentOptionSet> ParamOptions { get; set; }
    }
}
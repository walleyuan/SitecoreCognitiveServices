using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.SharedSource.CognitiveServices.OleChat.Models;

namespace Sitecore.SharedSource.CognitiveServices.OleChat.Dialog
{
    public class ConversationParameter
    {
        public ConversationParameter(string name, string message, Func<string, ItemContextParameters, IConversation, bool> validation)
        {
            ParamName = name;
            ParamMessage = message;
            ParamValidation = validation;
        }

        public string ParamName { get; set; }
        public string ParamMessage { get; set; }
        public Func<string, ItemContextParameters, IConversation, bool> ParamValidation { get; set; }
    }
}
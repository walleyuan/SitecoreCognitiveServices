using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Feature.OleChat.Models
{
    public class ConversationResponse
    {
        public string Message { get; set; }
        public Dictionary<string, string> Options { get; set; }
        public string Action { get; set; }
    }
}
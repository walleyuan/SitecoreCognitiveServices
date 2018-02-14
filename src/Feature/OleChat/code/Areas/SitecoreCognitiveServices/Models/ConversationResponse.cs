using System.Collections.Generic;

namespace SitecoreCognitiveServices.Feature.OleChat.Areas.SitecoreCognitiveServices.Models
{
    public class ConversationResponse
    {
        public string Message { get; set; }
        public IntentOptionSet OptionsSet { get; set; }
        public string Action { get; set; }
        public Dictionary<string, string> Selections { get; set; }
    }
}
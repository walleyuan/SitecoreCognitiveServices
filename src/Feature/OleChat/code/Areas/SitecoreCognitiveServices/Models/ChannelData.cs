using System.Collections.Generic;
using SitecoreCognitiveServices.Feature.OleChat.Models;

namespace SitecoreCognitiveServices.Feature.OleChat.Areas.SitecoreCognitiveServices.Models
{
    public class ChannelData
    {
        public IntentOptionSet OptionSet { get; set; }
        public Dictionary<string, string> Selections { get; set; }
        public string Action { get; set; }
    }
}
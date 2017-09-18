using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.SharedSource.CognitiveServices.Models.Language.Luis.Connector;

namespace Sitecore.SharedSource.CognitiveServices.OleChat.Models
{
    public class ChannelData
    {
        public List<Option> Options { get; set; }
        public KeyValuePair<string, string> Action { get; set; }
    }
}
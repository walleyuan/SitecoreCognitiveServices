using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SitecoreCognitiveServices.Feature.OleChat.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Feature.OleChat.Models
{
    public class IntentOptionSet
    {
        public IntentOptionType Type { get; set; }
        public string OptionType { get
            {
                return Enum.GetName(typeof(IntentOptionType), Type);
            }
        }
        public List<string> Options { get; set; }
        
        public void AddOption(string value)
        {
            Options.Add(value);
        }
    }
}
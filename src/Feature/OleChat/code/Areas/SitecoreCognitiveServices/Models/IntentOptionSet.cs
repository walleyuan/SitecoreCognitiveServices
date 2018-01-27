using System;
using System.Collections.Generic;

namespace SitecoreCognitiveServices.Feature.OleChat.Areas.SitecoreCognitiveServices.Models
{
    public class IntentOptionSet
    {
        public IntentOptionType Type { get; set; }
        public string OptionType => Enum.GetName(typeof(IntentOptionType), Type);
        public List<string> Options { get; set; }
        
        public void AddOption(string value)
        {
            Options.Add(value);
        }
    }
}
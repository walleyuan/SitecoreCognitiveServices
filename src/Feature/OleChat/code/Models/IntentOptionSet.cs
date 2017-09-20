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
        public List<IntentOption> Options { get; set; }

        protected readonly IIntentOptionFactory IntentOptionFactory;

        public IntentOptionSet(IIntentOptionFactory optionFactory)
        {
            IntentOptionFactory = optionFactory;
            Options = new List<IntentOption>();
        }

        public void AddOption(string displayText, string value)
        {
            var option = IntentOptionFactory.Create(displayText, value);
            Options.Add(option);
        }
    }
}
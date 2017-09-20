using SitecoreCognitiveServices.Feature.OleChat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Feature.OleChat.Factories
{
    public interface IIntentOptionFactory
    {
        IntentOption Create(string displayText, string value);
    }

    public class IntentOptionFactory : IIntentOptionFactory
    {
        public IntentOption Create(string displayText, string value)
        {
            return new IntentOption
            {
                DisplayText = displayText,
                Value = value
            };
        }
    }
}
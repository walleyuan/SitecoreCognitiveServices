using SitecoreCognitiveServices.Feature.OleChat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SitecoreCognitiveServices.Feature.OleChat.Areas.SitecoreCognitiveServices.Models;

namespace SitecoreCognitiveServices.Feature.OleChat.Factories
{
    public interface IIntentOptionSetFactory
    {
        IntentOptionSet Create(IntentOptionType type);
        IntentOptionSet Create(IntentOptionType type, List<string> options);
    }

    public class IntentOptionSetFactory : IIntentOptionSetFactory
    {
        public IntentOptionSet Create(IntentOptionType type)
        {
            return new IntentOptionSet()
            {
                Type = type,
                Options = new List<string>()
            };
        }

        public IntentOptionSet Create(IntentOptionType type, List<string> options)
        {
            var os = Create(type);
            os.Options = options;

            return os;
        }
    }
}
using SitecoreCognitiveServices.Feature.OleChat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Feature.OleChat.Factories
{
    public interface IIntentOptionSetFactory
    {
        IntentOptionSet Create(IntentOptionType type);
        IntentOptionSet Create(IntentOptionType type, List<IntentOption> options);
        IntentOptionSet Create(IntentOptionType type, Dictionary<string, string> options);
    }

    public class IntentOptionSetFactory : IIntentOptionSetFactory
    {
        protected readonly IIntentOptionFactory IntentOptionFactory;

        public IntentOptionSetFactory(IIntentOptionFactory optionFactory)
        {
            IntentOptionFactory = optionFactory;
        }

        public IntentOptionSet Create(IntentOptionType type)
        {
            return new IntentOptionSet(IntentOptionFactory)
            {
                Type = type
            };
        }

        public IntentOptionSet Create(IntentOptionType type, List<IntentOption> options)
        {
            var os = Create(type);
            os.Options = options;

            return os;
        }

        public IntentOptionSet Create(IntentOptionType type, Dictionary<string, string> options)
        {
            List<IntentOption> iOptions = options.Select(o => IntentOptionFactory.Create(o.Key, o.Value)).ToList();

            return Create(type, iOptions);
        }
    }
}
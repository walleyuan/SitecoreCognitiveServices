using System;
using System.Collections.Generic;

namespace Sitecore.SharedSource.CognitiveServices.Intents {
    public class IntentProvider : IIntentProvider
    {
        private readonly Dictionary<string, IIntent> _intentDictionary;
        
        public IntentProvider()
        {
            DefaultIntent d = new DefaultIntent();
            CursingIntent c = new CursingIntent();
            GreetIntent g = new GreetIntent();
            VersionIntent v = new VersionIntent();

            _intentDictionary = new Dictionary<string, IIntent>()
            {
                { d.Name, d },
                { c.Name, c },
                { g.Name, g },
                { v.Name, v }
            };

        }

        public IIntent GetIntent(Guid appId, string intentName)
        {
            return (_intentDictionary.ContainsKey(intentName))
                ? _intentDictionary[intentName]
                : null;
        }
    }
}
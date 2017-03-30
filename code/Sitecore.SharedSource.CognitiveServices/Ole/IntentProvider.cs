using System;
using System.Collections.Generic;
using Sitecore.SharedSource.CognitiveServices.Ole;
using Sitecore.SharedSource.CognitiveServices.Ole.Intents;

namespace Sitecore.SharedSource.CognitiveServices.Ole {
    public class IntentProvider : IIntentProvider
    {
        private readonly Dictionary<string, IIntent> _intentDictionary;
        
        public IntentProvider()
        {
            DefaultIntent d = new DefaultIntent();
            CursingIntent c = new CursingIntent();
            GreetIntent g = new GreetIntent();
            VersionIntent v = new VersionIntent();
            LoggedInUsersIntent l = new LoggedInUsersIntent();
            KickUserIntent k = new KickUserIntent();

            _intentDictionary = new Dictionary<string, IIntent>()
            {
                { d.Name.ToLower(), d },
                { c.Name.ToLower(), c },
                { g.Name.ToLower(), g },
                { v.Name.ToLower(), v },
                { l.Name.ToLower(), l },
                { k.Name.ToLower(), k }
            };
        }

        public IIntent GetIntent(Guid appId, string intentName)
        {
            var caseSensitiveName = intentName.ToLower();

            return (_intentDictionary.ContainsKey(caseSensitiveName))
                ? _intentDictionary[caseSensitiveName]
                : null;
        }
    }
}
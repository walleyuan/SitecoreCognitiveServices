using System;
using System.Collections.Generic;
using System.Linq;
using Sitecore.SharedSource.CognitiveServices.Factories.Intents;
using Sitecore.SharedSource.CognitiveServices.Ole.Intents;

namespace Sitecore.SharedSource.CognitiveServices.Ole {
    public class IntentProvider : IIntentProvider
    {
        private readonly Dictionary<string, IIntent> _intentDictionary;
        
        public IntentProvider(
            IDefaultIntentFactory defaultFactory,
            IGreetIntentFactory greetFactory,
            IVersionIntentFactory versionFactory,
            ILoggedInUsersIntentFactory loggedInFactory,
            IKickUserIntentFactory kickFactory,
            IPublishIntentFactory publishFactory
            )
        {
            List<IBaseIntentFactory<IIntent>> f = new List<IBaseIntentFactory<IIntent>>()
            {
                defaultFactory, greetFactory, versionFactory, loggedInFactory, kickFactory, publishFactory
            };

            _intentDictionary = f.Select(a => a.Create()).ToDictionary(a => a.Name);
        }

        public IIntent GetIntent(Guid appId, string intentName)
        {
            var caseSensitiveName = intentName.ToLower();

            return (_intentDictionary.ContainsKey(caseSensitiveName))
                ? _intentDictionary[caseSensitiveName]
                : null;
        }

        public string GetDefaultResponse(Guid appId)
        {
            return GetIntent(appId, "default")?.Respond(null, null) ?? string.Empty;
        }
    }
}
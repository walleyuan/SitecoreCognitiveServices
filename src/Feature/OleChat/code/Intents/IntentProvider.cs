using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using SitecoreCognitiveServices.Feature.OleChat.Factories;
using SitecoreCognitiveServices.Feature.OleChat.Models;

namespace SitecoreCognitiveServices.Feature.OleChat.Intents
{
    public class IntentProvider : IIntentProvider
    {
        private readonly Dictionary<Guid, Dictionary<string, IIntent>> _intentDictionary;
        protected readonly IConversationResponseFactory ConversationResponseFactory;

        public IntentProvider(
            IServiceProvider provider,
            IConversationResponseFactory reponseFactory)
        {
            _intentDictionary = provider.GetServices<IIntentFactory<IIntent>>()
                .Select(a => a.Create())
                .GroupBy(g => g.ApplicationId)
                .ToDictionary(a => a.Key, a => a.ToDictionary(b => b.Name));

            ConversationResponseFactory = reponseFactory;
        }

        public Dictionary<string, IIntent> GetAllIntents(Guid appId)
        {
            if (!_intentDictionary.ContainsKey(appId))
                return null;

            return _intentDictionary[appId];
        }

        public IIntent GetIntent(Guid appId, string intentName)
        {
            var appDictionary = GetAllIntents(appId);
            if (appDictionary == null)
                return null;

            var caseSensitiveName = intentName.ToLower();

            return (appDictionary.ContainsKey(caseSensitiveName))
                ? appDictionary[caseSensitiveName]
                : null;
        }

        public ConversationResponse GetDefaultResponse(Guid appId)
        {
            return GetIntent(appId, "none")?.Respond(null, null, null) ?? ConversationResponseFactory.Create(string.Empty);
        }
    }
}
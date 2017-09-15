using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Sitecore.SharedSource.CognitiveServices.OleChat.Factories;
using Sitecore.SharedSource.CognitiveServices.OleChat.Models;

namespace Sitecore.SharedSource.CognitiveServices.OleChat.Intents
{
    public class IntentProvider : IIntentProvider
    {
        private readonly Dictionary<Guid, Dictionary<string, IIntent>> _intentDictionary;
        
        public IntentProvider(IServiceProvider provider)
        {
            _intentDictionary = provider.GetServices<IIntentFactory<IIntent>>()
                .Select(a => a.Create())
                .GroupBy(g => g.ApplicationId)
                .ToDictionary(a => a.Key, a => a.ToDictionary(b => b.Name));
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
            return GetIntent(appId, "default")?.Respond(null, null, null) ?? new ConversationResponse { Message = string.Empty };
        }
    }
}
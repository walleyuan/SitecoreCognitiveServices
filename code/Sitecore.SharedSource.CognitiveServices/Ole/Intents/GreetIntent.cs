using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Bot.Builder.Luis.Models;
using Sitecore.SharedSource.CognitiveServices.Foundation;
using Microsoft.SharedSource.CognitiveServices.Models.Language.Luis;

namespace Sitecore.SharedSource.CognitiveServices.Ole.Intents {
    public class GreetIntent : IIntent
    {
        public string Name => "greet";

        public string Respond(ITextTranslator translator, QueryResult result, Dictionary<string, string> parameters)
        {
            return "Hi, how can I help you?";
        }
    }
}
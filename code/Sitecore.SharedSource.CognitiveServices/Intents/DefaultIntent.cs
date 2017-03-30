using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Bot.Builder.Luis.Models;
using Sitecore.SharedSource.CognitiveServices.Foundation;
using Sitecore.SharedSource.CognitiveServices.Models.Language.Luis;

namespace Sitecore.SharedSource.CognitiveServices.Intents {
    public class DefaultIntent : IIntent {
        public string Name => "default";

        public string Respond(ITextTranslator translator, QueryResult result, Dictionary<string, string> parameters) {
            return "Sorry, can you try again? I didn't quite understand you.";
        }
    }
}
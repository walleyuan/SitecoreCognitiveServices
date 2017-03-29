using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Bot.Builder.Luis.Models;
using Sitecore.SharedSource.CognitiveServices.Foundation;
using Sitecore.SharedSource.CognitiveServices.Models.Language.Luis;

namespace Sitecore.SharedSource.CognitiveServices.Intents {
    public class CursingIntent : IIntent {
        public string Name => "cursing";

        public string Respond(ITextTranslator translator, QueryResult result) {
            return "You really shouldn't talk like that";
        }
    }
}
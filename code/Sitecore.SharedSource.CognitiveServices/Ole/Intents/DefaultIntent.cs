using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Bot.Builder.Luis.Models;
using Sitecore.SharedSource.CognitiveServices.Foundation;
using Microsoft.SharedSource.CognitiveServices.Models.Language.Luis;
using Sitecore.SharedSource.CognitiveServices.Models.Ole;

namespace Sitecore.SharedSource.CognitiveServices.Ole.Intents {

    public interface IDefaultIntent : IIntent { }

    public class DefaultIntent : IDefaultIntent {

        protected readonly ITextTranslator Translator;
        
        public string Name => "default";

        public DefaultIntent(ITextTranslator translator) {
            Translator = translator;
        }
        
        public string Respond(QueryResult result, ItemContextParameters parameters) {
            return "Sorry, can you try again? I didn't quite understand you.";
        }
    }
}
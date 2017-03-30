using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Bot.Builder.Luis.Models;
using Sitecore.SharedSource.CognitiveServices.Foundation;
using Microsoft.SharedSource.CognitiveServices.Models.Language.Luis;

namespace Sitecore.SharedSource.CognitiveServices.Ole.Intents {
    public interface IIntent {
        string Name { get; }
        string Respond(ITextTranslator translator, QueryResult result, Dictionary<string, string> parameters);
    }
}
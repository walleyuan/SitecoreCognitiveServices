using Sitecore.SharedSource.CognitiveServices.Foundation;
using Microsoft.SharedSource.CognitiveServices.Models.Language.Luis;
using Sitecore.SharedSource.CognitiveServices.Models.Ole;

namespace Sitecore.SharedSource.CognitiveServices.Ole.Intents {
    public interface IIntent {
        string Name { get; }
        string Respond(QueryResult result, ItemContextParameters parameters);
    }
}
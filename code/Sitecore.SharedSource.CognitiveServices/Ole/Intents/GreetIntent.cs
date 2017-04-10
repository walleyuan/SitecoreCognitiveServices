using Sitecore.SharedSource.CognitiveServices.Foundation;
using Microsoft.SharedSource.CognitiveServices.Models.Language.Luis;
using Sitecore.SharedSource.CognitiveServices.Models.Ole;

namespace Sitecore.SharedSource.CognitiveServices.Ole.Intents {
    public interface IGreetIntent : IIntent { }

    public class GreetIntent : IGreetIntent
    {
        protected readonly ITextTranslator Translator;

        public string Name => "greet";

        public GreetIntent(ITextTranslator translator) {
            Translator = translator;
        }

        public string Respond(QueryResult result, ItemContextParameters parameters)
        {
            string fullName = Sitecore.Context.User.Profile.FullName;
            
            return $"Hi {fullName}, how can I help you?";
        }
    }
}
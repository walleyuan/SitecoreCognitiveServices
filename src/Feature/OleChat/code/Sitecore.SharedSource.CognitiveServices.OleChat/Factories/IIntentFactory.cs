using Sitecore.SharedSource.CognitiveServices.OleChat.Intents;

namespace Sitecore.SharedSource.CognitiveServices.OleChat.Factories {
    public interface IIntentFactory<out T> where T : IIntent {
        T Create();
    }
}
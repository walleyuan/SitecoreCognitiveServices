using SitecoreCognitiveServices.Feature.OleChat.Intents;

namespace SitecoreCognitiveServices.Feature.OleChat.Factories {
    public interface IIntentFactory<out T> where T : IIntent {
        T Create();
    }
}
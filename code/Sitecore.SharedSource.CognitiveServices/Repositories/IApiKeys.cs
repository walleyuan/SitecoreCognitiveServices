
namespace Sitecore.SharedSource.CognitiveServices
{
    public interface IApiKeys
    {
        string TextAnalytics { get; }
        string Recommendations { get; }
        string Academic { get; }
        string ComputerVision { get; }
        string Video { get; }
        string WebLM { get; }
        string EntityLinking { get; }
        string LinguisticAnalysis { get; }
        string Face { get; }
        string Emotion { get; }
        string SpeakerRecognition { get; }
        string BingSpeech { get; }
        string BingSpellCheck { get; }
        string BingAutosuggest { get; }
        string BingSearch { get; }
    }
}

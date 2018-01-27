
namespace SitecoreCognitiveServices.Foundation.MSSDK
{
    public interface IMicrosoftCognitiveServicesApiKeys
    {
        string Academic { get; set; }
        string AcademicEndpoint { get; }
        int AcademicRetryInSeconds { get; }
        string BingSpeech { get; set; }
        string BingSpeechEndpoint { get; }
        int BingSpeechRetryInSeconds { get; }
        string BingSpellCheck { get; set; }
        string BingSpellCheckEndpoint { get; }
        int BingSpellCheckRetryInSeconds { get; }
        string BingAutosuggest { get; set; }
        string BingAutosuggestEndpoint { get; }
        int BingAutosuggestRetryInSeconds { get; }
        string BingSearch { get; set; }
        string BingSearchEndpoint { get; }
        int BingSearchRetryInSeconds { get; }
        string ComputerVision { get; set; }
        string ComputerVisionEndpoint { get; }
        int ComputerVisionRetryInSeconds { get; }
        string ContentModerator { get; set; }
        string ContentModeratorClientId { get; }
        string ContentModeratorPrivateKey { get; }
        string ContentModeratorEndpoint { get; }
        int ContentModeratorRetryInSeconds { get; }
        string EntityLinking { get; set; }
        string EntityLinkingEndpoint { get; }
        int EntityLinkingRetryInSeconds { get; }
        string Emotion { get; set; }
        string EmotionEndpoint { get; }
        int EmotionRetryInSeconds { get; }
        string Face { get; set; }
        string FaceEndpoint { get; }
        int FaceRetryInSeconds { get; }
        string LinguisticAnalysis { get; set; }
        string LinguisticAnalysisEndpoint { get; }
        int LinguisticAnalysisRetryInSeconds { get; }
        string Luis { get; set; }
        string LuisEndpoint { get; }
        int LuisRetryInSeconds { get; }
        string QnA { get; set; }
        string QnAEndpoint { get; }
        int QnARetryInSeconds { get; }
        string Recommendations { get; set; }
        string RecommendationsEndpoint { get; }
        int RecommendationsRetryInSeconds { get; }
        string SpeakerRecognition { get; set; }
        string SpeakerRecognitionEndpoint { get; }
        int SpeakerRecognitionRetryInSeconds { get; }
        string TextAnalytics { get; set; }
        string TextAnalyticsEndpoint { get; }
        int TextAnalyticsRetryInSeconds { get; }
        string Video { get; set; }
        string VideoEndpoint { get; }
        int VideoRetryInSeconds { get; }
        string WebLM { get; set; }
        string WebLMEndpoint { get; }
        int WebLMRetryInSeconds { get; }
        string GetStringValue(string fieldName);
        int GetIntValue(string fieldName);
    }
}

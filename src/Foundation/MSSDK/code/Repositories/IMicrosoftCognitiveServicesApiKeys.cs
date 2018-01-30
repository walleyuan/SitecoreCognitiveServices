
namespace SitecoreCognitiveServices.Foundation.MSSDK
{
    public interface IMicrosoftCognitiveServicesApiKeys
    {
        string Academic { get; set; }
        string AcademicEndpoint { get; set; }
        int AcademicRetryInSeconds { get; }
        string BingSpeech { get; set; }
        string BingSpeechEndpoint { get; set; }
        int BingSpeechRetryInSeconds { get; }
        string BingSpellCheck { get; set; }
        string BingSpellCheckEndpoint { get; set; }
        int BingSpellCheckRetryInSeconds { get; }
        string BingAutosuggest { get; set; }
        string BingAutosuggestEndpoint { get; set; }
        int BingAutosuggestRetryInSeconds { get; }
        string BingSearch { get; set; }
        string BingSearchEndpoint { get; set; }
        int BingSearchRetryInSeconds { get; }
        string ComputerVision { get; set; }
        string ComputerVisionEndpoint { get; set; }
        int ComputerVisionRetryInSeconds { get; }
        string ContentModerator { get; set; }
        string ContentModeratorClientId { get; }
        string ContentModeratorPrivateKey { get; }
        string ContentModeratorEndpoint { get; set; }
        int ContentModeratorRetryInSeconds { get; }
        string EntityLinking { get; set; }
        string EntityLinkingEndpoint { get; set; }
        int EntityLinkingRetryInSeconds { get; }
        string Emotion { get; set; }
        string EmotionEndpoint { get; set; }
        int EmotionRetryInSeconds { get; }
        string Face { get; set; }
        string FaceEndpoint { get; set; }
        int FaceRetryInSeconds { get; }
        string LinguisticAnalysis { get; set; }
        string LinguisticAnalysisEndpoint { get; set; }
        int LinguisticAnalysisRetryInSeconds { get; }
        string Luis { get; set; }
        string LuisEndpoint { get; set; }
        int LuisRetryInSeconds { get; }
        string QnA { get; set; }
        string QnAEndpoint { get; set; }
        int QnARetryInSeconds { get; }
        string Recommendations { get; set; }
        string RecommendationsEndpoint { get; set; }
        int RecommendationsRetryInSeconds { get; }
        string SpeakerRecognition { get; set; }
        string SpeakerRecognitionEndpoint { get; set; }
        int SpeakerRecognitionRetryInSeconds { get; }
        string TextAnalytics { get; set; }
        string TextAnalyticsEndpoint { get; set; }
        int TextAnalyticsRetryInSeconds { get; }
        string Video { get; set; }
        string VideoEndpoint { get; set; }
        int VideoRetryInSeconds { get; }
        string WebLM { get; set; }
        string WebLMEndpoint { get; set; }
        int WebLMRetryInSeconds { get; }
        string GetStringValue(string fieldName);
        int GetIntValue(string fieldName);
    }
}

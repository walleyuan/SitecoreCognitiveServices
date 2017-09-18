using SitecoreCognitiveServices.Foundation.MSSDK;
using Sitecore.Configuration;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Repositories
{
    public class ApiKeys : IApiKeys
    {
        public virtual string Academic => Settings.GetSetting("CognitiveService.ApiKey.Academic");
        public virtual string AcademicEndpoint => Settings.GetSetting("CognitiveService.ApiKey.Academic.Endpoint");
        public virtual string BingSpeech => Settings.GetSetting("CognitiveService.ApiKey.BingSpeech");
        public virtual string BingSpeechEndpoint => Settings.GetSetting("CognitiveService.ApiKey.BingSpeech.Endpoint");
        public virtual string BingSpellCheck => Settings.GetSetting("CognitiveService.ApiKey.BingSpellCheck");
        public virtual string BingSpellCheckEndpoint => Settings.GetSetting("CognitiveService.ApiKey.BingSpellCheck.Endpoint");
        public virtual string BingAutosuggest => Settings.GetSetting("CognitiveService.ApiKey.BingAutosuggest");
        public virtual string BingAutosuggestEndpoint => Settings.GetSetting("CognitiveService.ApiKey.BingAutosuggest.Endpoint");
        public virtual string BingSearch => Settings.GetSetting("CognitiveService.ApiKey.BingSearch");
        public virtual string BingSearchEndpoint => Settings.GetSetting("CognitiveService.ApiKey.BingSearch.Endpoint");
        public virtual string ComputerVision => Settings.GetSetting("CognitiveService.ApiKey.ComputerVision");
        public virtual string ComputerVisionEndpoint => Settings.GetSetting("CognitiveService.ApiKey.ComputerVision.Endpoint");
        public virtual string ContentModerator => Settings.GetSetting("CognitiveService.ApiKey.ContentModerator");
        public virtual string ContentModeratorClientId => Settings.GetSetting("CognitiveService.ApiKey.ContentModerator.ClientId");
        public virtual string ContentModeratorPrivateKey => Settings.GetSetting("CognitiveService.ApiKey.ContentModerator.PrivateKey");
        public virtual string ContentModeratorEndpoint => Settings.GetSetting("CognitiveService.ApiKey.ContentModerator.Endpoint");
        public virtual string EntityLinking => Settings.GetSetting("CognitiveService.ApiKey.EntityLinking");
        public virtual string EntityLinkingEndpoint => Settings.GetSetting("CognitiveService.ApiKey.EntityLinking.Endpoint");
        public virtual string Emotion => Settings.GetSetting("CognitiveService.ApiKey.Emotion");
        public virtual string EmotionEndpoint => Settings.GetSetting("CognitiveService.ApiKey.Emotion.Endpoint");
        public virtual string Face => Settings.GetSetting("CognitiveService.ApiKey.Face");
        public virtual string FaceEndpoint => Settings.GetSetting("CognitiveService.ApiKey.Face.Endpoint");
        public virtual string LinguisticAnalysis => Settings.GetSetting("CognitiveService.ApiKey.LinguisticAnalysis");
        public virtual string LinguisticAnalysisEndpoint => Settings.GetSetting("CognitiveService.ApiKey.LinguisticAnalysis.Endpoint");
        public virtual string Luis => Settings.GetSetting("CognitiveService.ApiKey.Luis");
        public virtual string LuisEndpoint => Settings.GetSetting("CognitiveService.ApiKey.Luis.Endpoint");
        public virtual string QnA => Settings.GetSetting("CognitiveService.ApiKey.QnA");
        public virtual string QnAEndpoint => Settings.GetSetting("CognitiveService.ApiKey.QnA.Endpoint");
        public virtual string Recommendations => Settings.GetSetting("CognitiveService.ApiKey.Recommendations");
        public virtual string RecommendationsEndpoint => Settings.GetSetting("CognitiveService.ApiKey.Recommendations.Endpoint");
        public virtual string SpeakerRecognition => Settings.GetSetting("CognitiveService.ApiKey.SpeakerRecognition");
        public virtual string SpeakerRecognitionEndpoint => Settings.GetSetting("CognitiveService.ApiKey.SpeakerRecognition.Endpoint");
        public virtual string TextAnalytics => Settings.GetSetting("CognitiveService.ApiKey.TextAnalytics");
        public virtual string TextAnalyticsEndpoint => Settings.GetSetting("CognitiveService.ApiKey.TextAnalytics.Endpoint");
        public virtual string Video => Settings.GetSetting("CognitiveService.ApiKey.Video");
        public virtual string VideoEndpoint => Settings.GetSetting("CognitiveService.ApiKey.Video.Endpoint");
        public virtual string WebLM => Settings.GetSetting("CognitiveService.ApiKey.WebLM");
        public virtual string WebLMEndpoint => Settings.GetSetting("CognitiveService.ApiKey.WebLM.Endpoint");
    }
}

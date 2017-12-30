using SitecoreCognitiveServices.Foundation.MSSDK;
using Sitecore.Configuration;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Repositories
{
    public class ApiKeys
    {
        public class MicrosoftCognitiveServicesApiKeys : IMicrosoftCognitiveServicesApiKeys
        { 
            public virtual string Academic => Settings.GetSetting("CognitiveService.ApiKey.MSSDK.Academic");
            public virtual string AcademicEndpoint => Settings.GetSetting("CognitiveService.ApiKey.MSSDK.Academic.Endpoint");
            public virtual string AcademicRetryInSeconds => Settings.GetSetting("CognitiveService.ApiKey.MSSDK.Academic.RetryInSeconds");
            public virtual string BingSpeech => Settings.GetSetting("CognitiveService.ApiKey.MSSDK.BingSpeech");
            public virtual string BingSpeechEndpoint => Settings.GetSetting("CognitiveService.ApiKey.MSSDK.BingSpeech.Endpoint");
            public virtual string BingSpeechRetryInSeconds => Settings.GetSetting("CognitiveService.ApiKey.MSSDK.BingSpeech.RetryInSeconds");
            public virtual string BingSpellCheck => Settings.GetSetting("CognitiveService.ApiKey.MSSDK.BingSpellCheck");
            public virtual string BingSpellCheckEndpoint => Settings.GetSetting("CognitiveService.ApiKey.MSSDK.BingSpellCheck.Endpoint");
            public virtual string BingSpellCheckRetryInSeconds => Settings.GetSetting("CognitiveService.ApiKey.MSSDK.BingSpellCheck.RetryInSeconds");
            public virtual string BingAutosuggest => Settings.GetSetting("CognitiveService.ApiKey.MSSDK.BingAutosuggest");
            public virtual string BingAutosuggestEndpoint => Settings.GetSetting("CognitiveService.ApiKey.MSSDK.BingAutosuggest.Endpoint");
            public virtual string BingAutosuggestRetryInSeconds => Settings.GetSetting("CognitiveService.ApiKey.MSSDK.BingAutosuggest.RetryInSeconds");
            public virtual string BingSearch => Settings.GetSetting("CognitiveService.ApiKey.MSSDK.BingSearch");
            public virtual string BingSearchEndpoint => Settings.GetSetting("CognitiveService.ApiKey.MSSDK.BingSearch.Endpoint");
            public virtual string BingSearchRetryInSeconds => Settings.GetSetting("CognitiveService.ApiKey.MSSDK.BingSearch.RetryInSeconds");
            public virtual string ComputerVision => Settings.GetSetting("CognitiveService.ApiKey.MSSDK.ComputerVision");
            public virtual string ComputerVisionEndpoint => Settings.GetSetting("CognitiveService.ApiKey.MSSDK.ComputerVision.Endpoint");
            public virtual string ComputerVisionRetryInSeconds => Settings.GetSetting("CognitiveService.ApiKey.MSSDK.ComputerVision.RetryInSeconds");
            public virtual string ContentModerator => Settings.GetSetting("CognitiveService.ApiKey.MSSDK.ContentModerator");
            public virtual string ContentModeratorClientId => Settings.GetSetting("CognitiveService.ApiKey.MSSDK.ContentModerator.ClientId");
            public virtual string ContentModeratorPrivateKey => Settings.GetSetting("CognitiveService.ApiKey.MSSDK.ContentModerator.PrivateKey");
            public virtual string ContentModeratorEndpoint => Settings.GetSetting("CognitiveService.ApiKey.MSSDK.ContentModerator.Endpoint");
            public virtual string ContentModeratorRetryInSeconds => Settings.GetSetting("CognitiveService.ApiKey.MSSDK.ContentModerator.RetryInSeconds");
            public virtual string EntityLinking => Settings.GetSetting("CognitiveService.ApiKey.MSSDK.EntityLinking");
            public virtual string EntityLinkingEndpoint => Settings.GetSetting("CognitiveService.ApiKey.MSSDK.EntityLinking.Endpoint");
            public virtual string EntityLinkingRetryInSeconds => Settings.GetSetting("CognitiveService.ApiKey.MSSDK.EntityLinking.RetryInSeconds");
            public virtual string Emotion => Settings.GetSetting("CognitiveService.ApiKey.MSSDK.Emotion");
            public virtual string EmotionEndpoint => Settings.GetSetting("CognitiveService.ApiKey.MSSDK.Emotion.Endpoint");
            public virtual string EmotionRetryInSeconds => Settings.GetSetting("CognitiveService.ApiKey.MSSDK.Emotion.RetryInSeconds");
            public virtual string Face => Settings.GetSetting("CognitiveService.ApiKey.MSSDK.Face");
            public virtual string FaceEndpoint => Settings.GetSetting("CognitiveService.ApiKey.MSSDK.Face.Endpoint");
            public virtual string FaceRetryInSeconds => Settings.GetSetting("CognitiveService.ApiKey.MSSDK.Face.RetryInSeconds");
            public virtual string LinguisticAnalysis => Settings.GetSetting("CognitiveService.ApiKey.MSSDK.LinguisticAnalysis");
            public virtual string LinguisticAnalysisEndpoint => Settings.GetSetting("CognitiveService.ApiKey.MSSDK.LinguisticAnalysis.Endpoint");
            public virtual string LinguisticAnalysisRetryInSeconds => Settings.GetSetting("CognitiveService.ApiKey.MSSDK.LinguisticAnalysis.RetryInSeconds");
            public virtual string Luis => Settings.GetSetting("CognitiveService.ApiKey.MSSDK.Luis");
            public virtual string LuisEndpoint => Settings.GetSetting("CognitiveService.ApiKey.MSSDK.Luis.Endpoint");
            public virtual string LuisRetryInSeconds => Settings.GetSetting("CognitiveService.ApiKey.MSSDK.Luis.RetryInSeconds");
            public virtual string QnA => Settings.GetSetting("CognitiveService.ApiKey.MSSDK.QnA");
            public virtual string QnAEndpoint => Settings.GetSetting("CognitiveService.ApiKey.MSSDK.QnA.Endpoint");
            public virtual string QnARetryInSeconds => Settings.GetSetting("CognitiveService.ApiKey.MSSDK.QnA.RetryInSeconds");
            public virtual string Recommendations => Settings.GetSetting("CognitiveService.ApiKey.MSSDK.Recommendations");
            public virtual string RecommendationsEndpoint => Settings.GetSetting("CognitiveService.ApiKey.MSSDK.Recommendations.Endpoint");
            public virtual string RecommendationsRetryInSeconds => Settings.GetSetting("CognitiveService.ApiKey.MSSDK.Recommendations.RetryInSeconds");
            public virtual string SpeakerRecognition => Settings.GetSetting("CognitiveService.ApiKey.MSSDK.SpeakerRecognition");
            public virtual string SpeakerRecognitionEndpoint => Settings.GetSetting("CognitiveService.ApiKey.MSSDK.SpeakerRecognition.Endpoint");
            public virtual string SpeakerRecognitionRetryInSeconds => Settings.GetSetting("CognitiveService.ApiKey.MSSDK.SpeakerRecognition.RetryInSeconds");
            public virtual string TextAnalytics => Settings.GetSetting("CognitiveService.ApiKey.MSSDK.TextAnalytics");
            public virtual string TextAnalyticsEndpoint => Settings.GetSetting("CognitiveService.ApiKey.MSSDK.TextAnalytics.Endpoint");
            public virtual string TextAnalyticsRetryInSeconds => Settings.GetSetting("CognitiveService.ApiKey.MSSDK.TextAnalytics.RetryInSeconds");
            public virtual string Video => Settings.GetSetting("CognitiveService.ApiKey.MSSDK.Video");
            public virtual string VideoEndpoint => Settings.GetSetting("CognitiveService.ApiKey.MSSDK.Video.Endpoint");
            public virtual string VideoRetryInSeconds => Settings.GetSetting("CognitiveService.ApiKey.MSSDK.Video.RetryInSeconds");
            public virtual string WebLM => Settings.GetSetting("CognitiveService.ApiKey.MSSDK.WebLM");
            public virtual string WebLMEndpoint => Settings.GetSetting("CognitiveService.ApiKey.MSSDK.WebLM.Endpoint");
            public virtual string WebLMRetryInSeconds => Settings.GetSetting("CognitiveService.ApiKey.MSSDK.WebLM.RetryInSeconds");
        }
    }
}

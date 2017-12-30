using System;
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
            public virtual int AcademicRetryInSeconds => Convert.ToInt32(Settings.GetSetting("CognitiveService.ApiKey.MSSDK.Academic.RetryInSeconds"));
            public virtual string BingSpeech => Settings.GetSetting("CognitiveService.ApiKey.MSSDK.BingSpeech");
            public virtual string BingSpeechEndpoint => Settings.GetSetting("CognitiveService.ApiKey.MSSDK.BingSpeech.Endpoint");
            public virtual int BingSpeechRetryInSeconds => Convert.ToInt32(Settings.GetSetting("CognitiveService.ApiKey.MSSDK.BingSpeech.RetryInSeconds"));
            public virtual string BingSpellCheck => Settings.GetSetting("CognitiveService.ApiKey.MSSDK.BingSpellCheck");
            public virtual string BingSpellCheckEndpoint => Settings.GetSetting("CognitiveService.ApiKey.MSSDK.BingSpellCheck.Endpoint");
            public virtual int BingSpellCheckRetryInSeconds => Convert.ToInt32(Settings.GetSetting("CognitiveService.ApiKey.MSSDK.BingSpellCheck.RetryInSeconds"));
            public virtual string BingAutosuggest => Settings.GetSetting("CognitiveService.ApiKey.MSSDK.BingAutosuggest");
            public virtual string BingAutosuggestEndpoint => Settings.GetSetting("CognitiveService.ApiKey.MSSDK.BingAutosuggest.Endpoint");
            public virtual int BingAutosuggestRetryInSeconds => Convert.ToInt32(Settings.GetSetting("CognitiveService.ApiKey.MSSDK.BingAutosuggest.RetryInSeconds"));
            public virtual string BingSearch => Settings.GetSetting("CognitiveService.ApiKey.MSSDK.BingSearch");
            public virtual string BingSearchEndpoint => Settings.GetSetting("CognitiveService.ApiKey.MSSDK.BingSearch.Endpoint");
            public virtual int BingSearchRetryInSeconds => Convert.ToInt32(Settings.GetSetting("CognitiveService.ApiKey.MSSDK.BingSearch.RetryInSeconds"));
            public virtual string ComputerVision => Settings.GetSetting("CognitiveService.ApiKey.MSSDK.ComputerVision");
            public virtual string ComputerVisionEndpoint => Settings.GetSetting("CognitiveService.ApiKey.MSSDK.ComputerVision.Endpoint");
            public virtual int ComputerVisionRetryInSeconds => Convert.ToInt32(Settings.GetSetting("CognitiveService.ApiKey.MSSDK.ComputerVision.RetryInSeconds"));
            public virtual string ContentModerator => Settings.GetSetting("CognitiveService.ApiKey.MSSDK.ContentModerator");
            public virtual string ContentModeratorClientId => Settings.GetSetting("CognitiveService.ApiKey.MSSDK.ContentModerator.ClientId");
            public virtual string ContentModeratorPrivateKey => Settings.GetSetting("CognitiveService.ApiKey.MSSDK.ContentModerator.PrivateKey");
            public virtual string ContentModeratorEndpoint => Settings.GetSetting("CognitiveService.ApiKey.MSSDK.ContentModerator.Endpoint");
            public virtual int ContentModeratorRetryInSeconds => Convert.ToInt32(Settings.GetSetting("CognitiveService.ApiKey.MSSDK.ContentModerator.RetryInSeconds"));
            public virtual string EntityLinking => Settings.GetSetting("CognitiveService.ApiKey.MSSDK.EntityLinking");
            public virtual string EntityLinkingEndpoint => Settings.GetSetting("CognitiveService.ApiKey.MSSDK.EntityLinking.Endpoint");
            public virtual int EntityLinkingRetryInSeconds => Convert.ToInt32(Settings.GetSetting("CognitiveService.ApiKey.MSSDK.EntityLinking.RetryInSeconds");
            public virtual string Emotion => Settings.GetSetting("CognitiveService.ApiKey.MSSDK.Emotion");
            public virtual string EmotionEndpoint => Settings.GetSetting("CognitiveService.ApiKey.MSSDK.Emotion.Endpoint");
            public virtual int EmotionRetryInSeconds => Convert.ToInt32(Settings.GetSetting("CognitiveService.ApiKey.MSSDK.Emotion.RetryInSeconds"));
            public virtual string Face => Settings.GetSetting("CognitiveService.ApiKey.MSSDK.Face");
            public virtual string FaceEndpoint => Settings.GetSetting("CognitiveService.ApiKey.MSSDK.Face.Endpoint");
            public virtual int FaceRetryInSeconds => Convert.ToInt32(Settings.GetSetting("CognitiveService.ApiKey.MSSDK.Face.RetryInSeconds"));
            public virtual string LinguisticAnalysis => Settings.GetSetting("CognitiveService.ApiKey.MSSDK.LinguisticAnalysis");
            public virtual string LinguisticAnalysisEndpoint => Settings.GetSetting("CognitiveService.ApiKey.MSSDK.LinguisticAnalysis.Endpoint");
            public virtual int LinguisticAnalysisRetryInSeconds => Convert.ToInt32(Settings.GetSetting("CognitiveService.ApiKey.MSSDK.LinguisticAnalysis.RetryInSeconds"));
            public virtual string Luis => Settings.GetSetting("CognitiveService.ApiKey.MSSDK.Luis");
            public virtual string LuisEndpoint => Settings.GetSetting("CognitiveService.ApiKey.MSSDK.Luis.Endpoint");
            public virtual int LuisRetryInSeconds => Convert.ToInt32(Settings.GetSetting("CognitiveService.ApiKey.MSSDK.Luis.RetryInSeconds"));
            public virtual string QnA => Settings.GetSetting("CognitiveService.ApiKey.MSSDK.QnA");
            public virtual string QnAEndpoint => Settings.GetSetting("CognitiveService.ApiKey.MSSDK.QnA.Endpoint");
            public virtual int QnARetryInSeconds => Convert.ToInt32(Settings.GetSetting("CognitiveService.ApiKey.MSSDK.QnA.RetryInSeconds"));
            public virtual string Recommendations => Settings.GetSetting("CognitiveService.ApiKey.MSSDK.Recommendations");
            public virtual string RecommendationsEndpoint => Settings.GetSetting("CognitiveService.ApiKey.MSSDK.Recommendations.Endpoint");
            public virtual int RecommendationsRetryInSeconds => Convert.ToInt32(Settings.GetSetting("CognitiveService.ApiKey.MSSDK.Recommendations.RetryInSeconds"));
            public virtual string SpeakerRecognition => Settings.GetSetting("CognitiveService.ApiKey.MSSDK.SpeakerRecognition");
            public virtual string SpeakerRecognitionEndpoint => Settings.GetSetting("CognitiveService.ApiKey.MSSDK.SpeakerRecognition.Endpoint");
            public virtual int SpeakerRecognitionRetryInSeconds => Convert.ToInt32(Settings.GetSetting("CognitiveService.ApiKey.MSSDK.SpeakerRecognition.RetryInSeconds"));
            public virtual string TextAnalytics => Settings.GetSetting("CognitiveService.ApiKey.MSSDK.TextAnalytics");
            public virtual string TextAnalyticsEndpoint => Settings.GetSetting("CognitiveService.ApiKey.MSSDK.TextAnalytics.Endpoint");
            public virtual int TextAnalyticsRetryInSeconds => Convert.ToInt32(Settings.GetSetting("CognitiveService.ApiKey.MSSDK.TextAnalytics.RetryInSeconds"));
            public virtual string Video => Settings.GetSetting("CognitiveService.ApiKey.MSSDK.Video");
            public virtual string VideoEndpoint => Settings.GetSetting("CognitiveService.ApiKey.MSSDK.Video.Endpoint");
            public virtual int VideoRetryInSeconds => Convert.ToInt32(Settings.GetSetting("CognitiveService.ApiKey.MSSDK.Video.RetryInSeconds"));
            public virtual string WebLM => Settings.GetSetting("CognitiveService.ApiKey.MSSDK.WebLM");
            public virtual string WebLMEndpoint => Settings.GetSetting("CognitiveService.ApiKey.MSSDK.WebLM.Endpoint");
            public virtual int WebLMRetryInSeconds => Convert.ToInt32(Settings.GetSetting("CognitiveService.ApiKey.MSSDK.WebLM.RetryInSeconds"));
        }
    }
}

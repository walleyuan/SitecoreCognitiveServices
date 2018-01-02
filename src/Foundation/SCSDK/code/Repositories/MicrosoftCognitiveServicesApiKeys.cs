using System;
using SitecoreCognitiveServices.Foundation.MSSDK;
using Sitecore.Configuration;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Repositories
{
    public class MicrosoftCognitiveServicesApiKeys : IMicrosoftCognitiveServicesApiKeys
    {
        #region Constructor 

        protected readonly ISitecoreDataWrapper DataWrapper;
        protected readonly IApplicationSettings Settings;

        public MicrosoftCognitiveServicesApiKeys(
            ISitecoreDataWrapper dataWrapper,
            IApplicationSettings settings)
        {
            DataWrapper = dataWrapper;
            Settings = settings;
        }

        #endregion Constructor 

        public virtual string Academic => GetStringValue("Academic");
        public virtual string AcademicEndpoint => GetStringValue("Academic Endpoint");
        public virtual int AcademicRetryInSeconds => GetIntValue("Academic Retry In Seconds");
        public virtual string BingSpeech => GetStringValue("Bing Speech");
        public virtual string BingSpeechEndpoint => GetStringValue("Bing Speech Endpoint");
        public virtual int BingSpeechRetryInSeconds => GetIntValue("Bing Speech Retry In Seconds");
        public virtual string BingSpellCheck => GetStringValue("Bing Spell Check");
        public virtual string BingSpellCheckEndpoint => GetStringValue("Bing Spell Check Endpoint");
        public virtual int BingSpellCheckRetryInSeconds => GetIntValue("Bing Spell Check Retry In Seconds");
        public virtual string BingAutosuggest => GetStringValue("Bing Autosuggest");
        public virtual string BingAutosuggestEndpoint => GetStringValue("Bing Autosuggest Endpoint");
        public virtual int BingAutosuggestRetryInSeconds => GetIntValue("Bing Autosuggest Retry In Seconds");
        public virtual string BingSearch => GetStringValue("Bing Search");
        public virtual string BingSearchEndpoint => GetStringValue("Bing Search Endpoint");
        public virtual int BingSearchRetryInSeconds => GetIntValue("Bing Search Retry In Seconds");
        public virtual string ComputerVision => GetStringValue("Computer Vision");
        public virtual string ComputerVisionEndpoint => GetStringValue("Computer Vision Endpoint");
        public virtual int ComputerVisionRetryInSeconds => GetIntValue("Computer Vision Retry In Seconds");
        public virtual string ContentModerator => GetStringValue("Content Moderator");
        public virtual string ContentModeratorClientId => GetStringValue("Content Moderator Client Id");
        public virtual string ContentModeratorPrivateKey => GetStringValue("Content Moderator Private Key");
        public virtual string ContentModeratorEndpoint => GetStringValue("Content Moderator Endpoint");
        public virtual int ContentModeratorRetryInSeconds => GetIntValue("Content Moderator Retry In Seconds");
        public virtual string EntityLinking => GetStringValue("Entity Linking");
        public virtual string EntityLinkingEndpoint => GetStringValue("Entity Linking Endpoint");
        public virtual int EntityLinkingRetryInSeconds => GetIntValue("Entity Linking Retry In Seconds");
        public virtual string Emotion => GetStringValue("Emotion");
        public virtual string EmotionEndpoint => GetStringValue("Emotion Endpoint");
        public virtual int EmotionRetryInSeconds => GetIntValue("Emotion Retry In Seconds");
        public virtual string Face => GetStringValue("Face");
        public virtual string FaceEndpoint => GetStringValue("Face Endpoint");
        public virtual int FaceRetryInSeconds => GetIntValue("Face Retry In Seconds");
        public virtual string LinguisticAnalysis => GetStringValue("Linguistic Analysis");
        public virtual string LinguisticAnalysisEndpoint => GetStringValue("Linguistic Analysis Endpoint");
        public virtual int LinguisticAnalysisRetryInSeconds => GetIntValue("Linguistic Analysis Retry In Seconds");
        public virtual string Luis => GetStringValue("Luis");
        public virtual string LuisEndpoint => GetStringValue("Luis Endpoint");
        public virtual int LuisRetryInSeconds => GetIntValue("Luis Retry In Seconds");
        public virtual string QnA => GetStringValue("Q n A");
        public virtual string QnAEndpoint => GetStringValue("Q n A Endpoint");
        public virtual int QnARetryInSeconds => GetIntValue("Q n A Retry In Seconds");
        public virtual string Recommendations => GetStringValue("Recommendations");
        public virtual string RecommendationsEndpoint => GetStringValue("Recommendations Endpoint");
        public virtual int RecommendationsRetryInSeconds => GetIntValue("Recommendations Retry In Seconds");
        public virtual string SpeakerRecognition => GetStringValue("Speaker Recognition");
        public virtual string SpeakerRecognitionEndpoint => GetStringValue("Speaker Recognition Endpoint");
        public virtual int SpeakerRecognitionRetryInSeconds => GetIntValue("Speaker Recognition Retry In Seconds");
        public virtual string TextAnalytics => GetStringValue("Text Analytics");
        public virtual string TextAnalyticsEndpoint => GetStringValue("Text Analytics Endpoint");
        public virtual int TextAnalyticsRetryInSeconds => GetIntValue("Text Analytics Retry In Seconds");
        public virtual string Video => GetStringValue("Video");
        public virtual string VideoEndpoint => GetStringValue("Video Endpoint");
        public virtual int VideoRetryInSeconds => GetIntValue("Video Retry In Seconds");
        public virtual string WebLM => GetStringValue("WebLM");
        public virtual string WebLMEndpoint => GetStringValue("WebLM Endpoint");
        public virtual int WebLMRetryInSeconds => GetIntValue("WebLM Retry In Seconds");

        public string GetStringValue(string fieldName)
        {
            return DataWrapper
                .ContentDatabase
                .GetItem(Settings.MSSDKId)
                [fieldName];
        }
        
        public int GetIntValue(string fieldName)
        {
            var value = GetStringValue(fieldName);
            return string.IsNullOrEmpty(value)
                ? 0
                : Convert.ToInt32(value);
        }
    }
}

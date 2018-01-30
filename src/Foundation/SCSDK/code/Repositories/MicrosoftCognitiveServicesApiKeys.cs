using System;
using Newtonsoft.Json;
using SitecoreCognitiveServices.Foundation.MSSDK;
using Sitecore.Configuration;
using Sitecore.Data.Items;
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

        public virtual string Academic
        {
            get => GetStringValue("Academic");
            set => SetValue("Academic", value);
        }
        public virtual string AcademicEndpoint
        {
            get => GetStringValue("Academic Endpoint");
            set => SetValue("Academic Endpoint", value);
        }
        public virtual int AcademicRetryInSeconds => GetIntValue("Academic Retry In Seconds");
        public virtual string BingSpeech
        {
            get => GetStringValue("Bing Speech");
            set => SetValue("Bing Speech", value);
        }
        public virtual string BingSpeechEndpoint
        {
            get => GetStringValue("Bing Speech Endpoint");
            set => SetValue("Bing Speech Endpoint", value);
        }
        public virtual int BingSpeechRetryInSeconds => GetIntValue("Bing Speech Retry In Seconds");
        public virtual string BingSpellCheck
        {
            get => GetStringValue("Bing Spell Check");
            set => SetValue("Bing Spell Check", value);
        }
        public virtual string BingSpellCheckEndpoint
        {
            get => GetStringValue("Bing Spell Check Endpoint");
            set =>SetValue("Bing Spell Check Endpoint", value);
        }
        public virtual int BingSpellCheckRetryInSeconds => GetIntValue("Bing Spell Check Retry In Seconds");
        public virtual string BingAutosuggest
        {
            get => GetStringValue("Bing Autosuggest");
            set => SetValue("Bing Autosuggest", value);
        }
        public virtual string BingAutosuggestEndpoint
        {
            get => GetStringValue("Bing Autosuggest Endpoint");
            set => SetValue("Bing Autosuggest Endpoint", value);
        }
        public virtual int BingAutosuggestRetryInSeconds => GetIntValue("Bing Autosuggest Retry In Seconds");
        public virtual string BingSearch
        {
            get => GetStringValue("Bing Search");
            set => SetValue("Bing Search", value);
        }
        public virtual string BingSearchEndpoint
        {
            get => GetStringValue("Bing Search Endpoint");
            set => SetValue("Bing Search Endpoint", value);
        }
        public virtual int BingSearchRetryInSeconds => GetIntValue("Bing Search Retry In Seconds");
        public virtual string ComputerVision
        {
            get => GetStringValue("Computer Vision");
            set => SetValue("Computer Vision", value);
        }
        public virtual string ComputerVisionEndpoint
        {
            get => GetStringValue("Computer Vision Endpoint");
            set => SetValue("Computer Vision Endpoint", value);
        }
        public virtual int ComputerVisionRetryInSeconds => GetIntValue("Computer Vision Retry In Seconds");
        public virtual string ContentModerator
        {
            get => GetStringValue("Content Moderator");
            set => SetValue("Content Moderator", value);
        }
        public virtual string ContentModeratorClientId => GetStringValue("Content Moderator Client Id");
        public virtual string ContentModeratorPrivateKey => GetStringValue("Content Moderator Private Key");
        public virtual string ContentModeratorEndpoint
        {
            get => GetStringValue("Content Moderator Endpoint");
            set => SetValue("Content Moderator Endpoint", value);
        }
        public virtual int ContentModeratorRetryInSeconds => GetIntValue("Content Moderator Retry In Seconds");
        public virtual string EntityLinking
        {
            get => GetStringValue("Entity Linking");
            set => SetValue("Entity Linking", value);
        }
        public virtual string EntityLinkingEndpoint
        {
            get => GetStringValue("Entity Linking Endpoint");
            set => SetValue("Entity Linking Endpoint", value);
        }
        public virtual int EntityLinkingRetryInSeconds => GetIntValue("Entity Linking Retry In Seconds");
        public virtual string Emotion
        {
            get => GetStringValue("Emotion");
            set => SetValue("Emotion", value);
        }
        public virtual string EmotionEndpoint
        {
            get => GetStringValue("Emotion Endpoint");
            set => SetValue("Emotion Endpoint", value);
        }
        public virtual int EmotionRetryInSeconds => GetIntValue("Emotion Retry In Seconds");
        public virtual string Face
        {
            get => GetStringValue("Face");
            set => SetValue("Face", value);
        }
        public virtual string FaceEndpoint
        {
            get => GetStringValue("Face Endpoint");
            set => SetValue("Face Endpoint", value);
        }
        public virtual int FaceRetryInSeconds => GetIntValue("Face Retry In Seconds");
        public virtual string LinguisticAnalysis
        {
            get => GetStringValue("Linguistic Analysis");
            set => SetValue("Linguistic Analysis", value);
        }
        public virtual string LinguisticAnalysisEndpoint
        {
            get => GetStringValue("Linguistic Analysis Endpoint");
            set => SetValue("Linguistic Analysis Endpoint", value);
        }
        public virtual int LinguisticAnalysisRetryInSeconds => GetIntValue("Linguistic Analysis Retry In Seconds");
        public virtual string Luis
        {
            get => GetStringValue("Luis");
            set => SetValue("Luis", value);
        }
        public virtual string LuisEndpoint
        {
            get => GetStringValue("Luis Endpoint");
            set => SetValue("Luis Endpoint", value);
        }
        public virtual int LuisRetryInSeconds => GetIntValue("Luis Retry In Seconds");
        public virtual string QnA
        {
            get => GetStringValue("Q n A");
            set => SetValue("Q n A", value);
        }
        public virtual string QnAEndpoint
        {
            get => GetStringValue("Q n A Endpoint");
            set => SetValue("Q n A Endpoint", value);
        }
        public virtual int QnARetryInSeconds => GetIntValue("Q n A Retry In Seconds");
        public virtual string Recommendations
        {
            get => GetStringValue("Recommendations");
            set => SetValue("Recommendations", value);
        }
        public virtual string RecommendationsEndpoint
        {
            get => GetStringValue("Recommendations Endpoint");
            set => SetValue("Recommendations Endpoint", value);
        }
        public virtual int RecommendationsRetryInSeconds => GetIntValue("Recommendations Retry In Seconds");
        public virtual string SpeakerRecognition
        {
            get => GetStringValue("Speaker Recognition");
            set => SetValue("Speaker Recognition", value);
        }
        public virtual string SpeakerRecognitionEndpoint
        {
            get => GetStringValue("Speaker Recognition Endpoint");
            set => SetValue("Speaker Recognition Endpoint", value);
        }
        public virtual int SpeakerRecognitionRetryInSeconds => GetIntValue("Speaker Recognition Retry In Seconds");
        public virtual string TextAnalytics
        {
            get => GetStringValue("Text Analytics");
            set => SetValue("Text Analytics", value);
        }
        public virtual string TextAnalyticsEndpoint
        {
            get => GetStringValue("Text Analytics Endpoint");
            set => SetValue("Text Analytics Endpoint", value);
        }
        public virtual int TextAnalyticsRetryInSeconds => GetIntValue("Text Analytics Retry In Seconds");
        public virtual string Video
        {
            get => GetStringValue("Video");
            set => SetValue("Video", value);
        }
        public virtual string VideoEndpoint
        {
            get => GetStringValue("Video Endpoint");
            set => SetValue("Video Endpoint", value);
        }
        public virtual int VideoRetryInSeconds => GetIntValue("Video Retry In Seconds");
        public virtual string WebLM
        {
            get => GetStringValue("WebLM");
            set => SetValue("WebLM", value);
        } 
        public virtual string WebLMEndpoint
        {
            get => GetStringValue("WebLM Endpoint");
            set => SetValue("WebLM Endpoint", value);
        }
        public virtual int WebLMRetryInSeconds => GetIntValue("WebLM Retry In Seconds");

        public string GetStringValue(string fieldName)
        {
            return DataWrapper
                .ContentDatabase
                .GetItem(Settings.MSSDKId)
                [fieldName];
        }

        public void SetValue(string fieldName, object value)
        {
            var settingsItem = DataWrapper.ContentDatabase.GetItem(Settings.MSSDKId);

            using (new EditContext(settingsItem, true, false))
            {
                settingsItem.Fields[fieldName].Value = value.ToString();
            }
        }

        public int GetIntValue(string fieldName)
        {
            var fieldValue = GetStringValue(fieldName);

            int value;
            return int.TryParse(fieldValue, out value)
                ? value
                : 0;
        }
    }
}

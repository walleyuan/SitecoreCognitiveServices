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
            get
            {
                return GetStringValue("Academic");
            }
            set
            {
                SetValue("Academic", value);
            }
        }
        public virtual string AcademicEndpoint => GetStringValue("Academic Endpoint");
        public virtual int AcademicRetryInSeconds => GetIntValue("Academic Retry In Seconds");
        public virtual string BingSpeech
        {
            get
            {
                return GetStringValue("Bing Speech");
            }
            set
            {
                SetValue("Bing Speech", value);
            }
        }
        public virtual string BingSpeechEndpoint => GetStringValue("Bing Speech Endpoint");
        public virtual int BingSpeechRetryInSeconds => GetIntValue("Bing Speech Retry In Seconds");
        public virtual string BingSpellCheck
        {
            get
            {
                return GetStringValue("Bing Spell Check");
            }
            set
            {
                SetValue("Bing Spell Check", value);
            }
        }
        public virtual string BingSpellCheckEndpoint => GetStringValue("Bing Spell Check Endpoint");
        public virtual int BingSpellCheckRetryInSeconds => GetIntValue("Bing Spell Check Retry In Seconds");
        public virtual string BingAutosuggest
        {
            get
            {
                return GetStringValue("Bing Autosuggest");
            }
            set
            {
                SetValue("Bing Autosuggest", value);
            }
        }
        public virtual string BingAutosuggestEndpoint => GetStringValue("Bing Autosuggest Endpoint");
        public virtual int BingAutosuggestRetryInSeconds => GetIntValue("Bing Autosuggest Retry In Seconds");
        public virtual string BingSearch
        {
            get
            {
                return GetStringValue("Bing Search");
            }
            set
            {
                SetValue("Bing Search", value);
            } 
        }
        public virtual string BingSearchEndpoint => GetStringValue("Bing Search Endpoint");
        public virtual int BingSearchRetryInSeconds => GetIntValue("Bing Search Retry In Seconds");
        public virtual string ComputerVision
        {
            get
            {
                return GetStringValue("Computer Vision");
            }
            set
            {
                SetValue("Computer Vision", value);
            } 
        }
        public virtual string ComputerVisionEndpoint => GetStringValue("Computer Vision Endpoint");
        public virtual int ComputerVisionRetryInSeconds => GetIntValue("Computer Vision Retry In Seconds");
        public virtual string ContentModerator
        {
            get
            {
                return GetStringValue("Content Moderator");
            }
            set
            {
                SetValue("Content Moderator", value);
            }
        }
        public virtual string ContentModeratorClientId => GetStringValue("Content Moderator Client Id");
        public virtual string ContentModeratorPrivateKey => GetStringValue("Content Moderator Private Key");
        public virtual string ContentModeratorEndpoint => GetStringValue("Content Moderator Endpoint");
        public virtual int ContentModeratorRetryInSeconds => GetIntValue("Content Moderator Retry In Seconds");
        public virtual string EntityLinking
        {
            get
            {
                return GetStringValue("Entity Linking");
            }
            set
            {
                SetValue("Entity Linking", value);
            }
        }
        public virtual string EntityLinkingEndpoint => GetStringValue("Entity Linking Endpoint");
        public virtual int EntityLinkingRetryInSeconds => GetIntValue("Entity Linking Retry In Seconds");
        public virtual string Emotion
        {
            get
            {
                return GetStringValue("Emotion");
            }
            set
            {
                SetValue("Emotion", value);
            }
        }
        public virtual string EmotionEndpoint => GetStringValue("Emotion Endpoint");
        public virtual int EmotionRetryInSeconds => GetIntValue("Emotion Retry In Seconds");
        public virtual string Face
        {
            get
            {
                return GetStringValue("Face");
            }
            set
            {
                SetValue("Face", value);
            }
        }
        public virtual string FaceEndpoint => GetStringValue("Face Endpoint");
        public virtual int FaceRetryInSeconds => GetIntValue("Face Retry In Seconds");
        public virtual string LinguisticAnalysis
        {
            get
            {
                return GetStringValue("Linguistic Analysis");
            }
            set
            {
                SetValue("Linguistic Analysis", value);
            }
        }
        public virtual string LinguisticAnalysisEndpoint => GetStringValue("Linguistic Analysis Endpoint");
        public virtual int LinguisticAnalysisRetryInSeconds => GetIntValue("Linguistic Analysis Retry In Seconds");
        public virtual string Luis
        {
            get
            {
                return GetStringValue("Luis");
            }
            set
            {
                SetValue("Luis", value);
            }
        }
        public virtual string LuisEndpoint => GetStringValue("Luis Endpoint");
        public virtual int LuisRetryInSeconds => GetIntValue("Luis Retry In Seconds");
        public virtual string QnA
        {
            get
            {
                return GetStringValue("Q n A");
            }
            set
            {
                SetValue("Q n A", value);
            }
        }
        public virtual string QnAEndpoint => GetStringValue("Q n A Endpoint");
        public virtual int QnARetryInSeconds => GetIntValue("Q n A Retry In Seconds");
        public virtual string Recommendations
        {
            get
            {
                return GetStringValue("Recommendations");
            }
            set
            {
                SetValue("Recommendations", value);
            }
        }
        public virtual string RecommendationsEndpoint => GetStringValue("Recommendations Endpoint");
        public virtual int RecommendationsRetryInSeconds => GetIntValue("Recommendations Retry In Seconds");
        public virtual string SpeakerRecognition
        {
            get
            {
                return GetStringValue("Speaker Recognition");
            }
            set
            {
                SetValue("Speaker Recognition", value);
            }
        }
        public virtual string SpeakerRecognitionEndpoint => GetStringValue("Speaker Recognition Endpoint");
        public virtual int SpeakerRecognitionRetryInSeconds => GetIntValue("Speaker Recognition Retry In Seconds");
        public virtual string TextAnalytics
        {
            get
            {
                return GetStringValue("Text Analytics");
            }
            set
            {
                SetValue("Text Analytics", value);
            }
        }
        public virtual string TextAnalyticsEndpoint => GetStringValue("Text Analytics Endpoint");
        public virtual int TextAnalyticsRetryInSeconds => GetIntValue("Text Analytics Retry In Seconds");
        public virtual string Video
        {
            get
            {
                return GetStringValue("Video");
            }
            set
            {
                SetValue("Video", value);
            }
        }
        public virtual string VideoEndpoint => GetStringValue("Video Endpoint");
        public virtual int VideoRetryInSeconds => GetIntValue("Video Retry In Seconds");
        public virtual string WebLM
        {
            get
            {
                return GetStringValue("WebLM");
            }
            set
            {
                SetValue("WebLM", value);
            }
        } 
        public virtual string WebLMEndpoint => GetStringValue("WebLM Endpoint");
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

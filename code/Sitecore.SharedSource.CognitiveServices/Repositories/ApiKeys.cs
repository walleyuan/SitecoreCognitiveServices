using Microsoft.SharedSource.CognitiveServices;
using Sitecore.Configuration;

namespace Sitecore.SharedSource.CognitiveServices.Repositories
{
    public class ApiKeys : IApiKeys
    {
        public virtual string Academic => Settings.GetSetting("CognitiveService.ApiKey.Academic");
        public virtual string BingSpeech => Settings.GetSetting("CognitiveService.ApiKey.BingSpeech");
        public virtual string BingSpellCheck => Settings.GetSetting("CognitiveService.ApiKey.BingSpellCheck");
        public virtual string BingAutosuggest => Settings.GetSetting("CognitiveService.ApiKey.BingAutosuggest");
        public virtual string BingSearch => Settings.GetSetting("CognitiveService.ApiKey.BingSearch");
        public virtual string ComputerVision => Settings.GetSetting("CognitiveService.ApiKey.ComputerVision");
        public virtual string ComputerVisionEndpoint => Settings.GetSetting("CognitiveService.ApiKey.ComputerVision.Endpoint");
        public virtual string ContentModerator => Settings.GetSetting("CognitiveService.ApiKey.ContentModerator");
        public virtual string ContentModeratorClientId => Settings.GetSetting("CognitiveService.ApiKey.ContentModerator.ClientId");
        public virtual string ContentModeratorPrivateKey => Settings.GetSetting("CognitiveService.ApiKey.ContentModerator.PrivateKey");
        public virtual string EntityLinking => Settings.GetSetting("CognitiveService.ApiKey.EntityLinking");
        public virtual string Emotion => Settings.GetSetting("CognitiveService.ApiKey.Emotion");
        public virtual string Face => Settings.GetSetting("CognitiveService.ApiKey.Face");
        public virtual string FaceEndpoint => Settings.GetSetting("CognitiveService.ApiKey.Face.Endpoint");
        public virtual string LinguisticAnalysis => Settings.GetSetting("CognitiveService.ApiKey.LinguisticAnalysis");
        public virtual string Luis => Settings.GetSetting("CognitiveService.ApiKey.Luis");
        public virtual string QnA => Settings.GetSetting("CognitiveService.ApiKey.QnA");
        public virtual string Recommendations => Settings.GetSetting("CognitiveService.ApiKey.Recommendations");
        public virtual string SpeakerRecognition => Settings.GetSetting("CognitiveService.ApiKey.SpeakerRecognition");
        public virtual string TextAnalytics => Settings.GetSetting("CognitiveService.ApiKey.TextAnalytics");
        public virtual string TextAnalyticsEndpoint => Settings.GetSetting("CognitiveService.ApiKey.TextAnalytics.Endpoint");
        public virtual string Video => Settings.GetSetting("CognitiveService.ApiKey.Video");
        public virtual string WebLM => Settings.GetSetting("CognitiveService.ApiKey.WebLM");
    }
}

 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
 using Sitecore.SharedSource.CognitiveServices.Api.Knowledge;
 using Sitecore.SharedSource.CognitiveServices.Api.Language;
 using Sitecore.SharedSource.CognitiveServices.Api.Speech;
 using Sitecore.SharedSource.CognitiveServices.Api.Video;
 using Sitecore.SharedSource.CognitiveServices.Api.Vision;

namespace Sitecore.SharedSource.CognitiveServices.Api
{
    public class CognitiveContext : ICognitiveContext
    {
        public IEmotionApi EmotionApi { get; set; }
        public IEntityLinkingApi EntityLinkingApi { get; set; }
        public IFaceApi FaceApi { get; set; }
        public ILanguageApi LanguageApi { get; set; }
        public ISentimentApi SentimentApi { get; set; }
        public ISpeakerIdentificationApi SpeakerIdentificationApi { get; set; }
        public ISpeakerVerificationApi SpeakerVerificationApi { get; set; }
        public IVideoApi VideoApi { get; set; }
        public IVisionApi VisionApi { get; set; }

        public CognitiveContext(
            IEmotionApi emotionApi,
            IEntityLinkingApi entityLinkingApi,
            IFaceApi faceApi,
            ILanguageApi languageApi,
            ISentimentApi sentimentApi,
            ISpeakerIdentificationApi speakerIdentificationApi,
            ISpeakerVerificationApi speakerVerificationApi,
            IVideoApi videoApi, 
            IVisionApi visionApi)
        {
            EmotionApi = emotionApi;
            EntityLinkingApi = entityLinkingApi;
            FaceApi = faceApi;
            LanguageApi = languageApi;
            SentimentApi = sentimentApi;
            SpeakerIdentificationApi = speakerIdentificationApi;
            SpeakerVerificationApi = speakerVerificationApi;
            VideoApi = videoApi;
            VisionApi = visionApi;
        }
    }
}
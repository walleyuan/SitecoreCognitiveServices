 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
 using Sitecore.SharedSource.CognitiveServices.Repository.Knowledge;
 using Sitecore.SharedSource.CognitiveServices.Repository.Language;
 using Sitecore.SharedSource.CognitiveServices.Repository.Speech;
 using Sitecore.SharedSource.CognitiveServices.Repository.Video;
 using Sitecore.SharedSource.CognitiveServices.Repository.Vision;

namespace Sitecore.SharedSource.CognitiveServices.Repository
{
    public class CognitiveRepositoryContext : ICognitiveRepositoryContext
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

        public CognitiveRepositoryContext(
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
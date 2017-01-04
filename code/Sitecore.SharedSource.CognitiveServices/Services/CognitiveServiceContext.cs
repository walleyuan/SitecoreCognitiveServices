using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.SharedSource.CognitiveServices.Services.Knowledge;
using Sitecore.SharedSource.CognitiveServices.Services.Language;
using Sitecore.SharedSource.CognitiveServices.Services.Speech;
using Sitecore.SharedSource.CognitiveServices.Services.Video;
using Sitecore.SharedSource.CognitiveServices.Services.Vision;

namespace Sitecore.SharedSource.CognitiveServices.Services
{
    public class CognitiveServiceContext : ICognitiveServiceContext
    {
        public IEmotionService EmotionService { get; set; }
        public IEntityLinkingService EntityLinkingService { get; set; }
        public IFaceService FaceService { get; set; }
        public ILanguageService LanguageService { get; set; }
        public ISentimentService SentimentService { get; set; }
        public ISpeakerIdentificationService SpeakerIdentificationService { get; set; }
        public ISpeakerVerificationService SpeakerVerificationService { get; set; }
        public IVideoService VideoService { get; set; }
        public IVisionService VisionService { get; set; }

        public CognitiveServiceContext(
            IEmotionService emotionService,
            IEntityLinkingService entityLinkingService,
            IFaceService faceService,
            ILanguageService languageService,
            ISentimentService sentimentService,
            ISpeakerIdentificationService speakerIdentificationService,
            ISpeakerVerificationService speakerVerificationService,
            IVideoService videoService,
            IVisionService visionService)
        {
            EmotionService = emotionService;
            EntityLinkingService = entityLinkingService;
            FaceService = faceService;
            LanguageService = languageService;
            SentimentService = sentimentService;
            SpeakerIdentificationService = speakerIdentificationService;
            SpeakerVerificationService = speakerVerificationService;
            VideoService = videoService;
            VisionService = visionService;
        }
    }
}
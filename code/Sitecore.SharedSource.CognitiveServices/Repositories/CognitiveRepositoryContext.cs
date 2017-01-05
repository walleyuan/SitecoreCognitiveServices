 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
 using Sitecore.SharedSource.CognitiveServices.Repositories.Knowledge;
 using Sitecore.SharedSource.CognitiveServices.Repositories.Language;
 using Sitecore.SharedSource.CognitiveServices.Repositories.Speech;
 using Sitecore.SharedSource.CognitiveServices.Repositories.Video;
 using Sitecore.SharedSource.CognitiveServices.Repositories.Vision;

namespace Sitecore.SharedSource.CognitiveServices.Repositories
{
    public class CognitiveRepositoryContext : ICognitiveRepositoryContext
    {
        public IEmotionRepository EmotionRepository { get; set; }
        public IEntityLinkingRepository EntityLinkingRepository { get; set; }
        public IFaceRepository FaceRepository { get; set; }
        public ILanguageRepository LanguageRepository { get; set; }
        public ISentimentRepository SentimentRepository { get; set; }
        public ISpeakerIdentificationRepository SpeakerIdentificationRepository { get; set; }
        public ISpeakerVerificationRepository SpeakerVerificationRepository { get; set; }
        public IVideoRepository VideoRepository { get; set; }
        public IVisionRepository VisionRepository { get; set; }

        public CognitiveRepositoryContext(
            IEmotionRepository emotionRepository,
            IEntityLinkingRepository entityLinkingRepository,
            IFaceRepository faceRepository,
            ILanguageRepository languageRepository,
            ISentimentRepository sentimentRepository,
            ISpeakerIdentificationRepository speakerIdentificationRepository,
            ISpeakerVerificationRepository speakerVerificationRepository,
            IVideoRepository videoRepository, 
            IVisionRepository visionRepository)
        {
            EmotionRepository = emotionRepository;
            EntityLinkingRepository = entityLinkingRepository;
            FaceRepository = faceRepository;
            LanguageRepository = languageRepository;
            SentimentRepository = sentimentRepository;
            SpeakerIdentificationRepository = speakerIdentificationRepository;
            SpeakerVerificationRepository = speakerVerificationRepository;
            VideoRepository = videoRepository;
            VisionRepository = visionRepository;
        }
    }
}
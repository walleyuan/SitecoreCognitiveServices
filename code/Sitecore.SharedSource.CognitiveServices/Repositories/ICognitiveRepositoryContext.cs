using Sitecore.SharedSource.CognitiveServices.Repositories.Knowledge;
using Sitecore.SharedSource.CognitiveServices.Repositories.Language;
using Sitecore.SharedSource.CognitiveServices.Repositories.Speech;
using Sitecore.SharedSource.CognitiveServices.Repositories.Video;
using Sitecore.SharedSource.CognitiveServices.Repositories.Vision;

namespace Sitecore.SharedSource.CognitiveServices.Repositories
{
    public interface ICognitiveRepositoryContext
    {
        IEmotionRepository EmotionRepository { get; set; }
        IEntityLinkingRepository EntityLinkingRepository { get; set; }
        IFaceRepository FaceRepository { get; set; }
        ILanguageRepository LanguageRepository { get; set; }
        ILinguisticRepository LinguisticRepository { get; set; }
        ISentimentRepository SentimentRepository { get; set; }
        ISpeakerIdentificationRepository SpeakerIdentificationRepository { get; set; }
        ISpeakerVerificationRepository SpeakerVerificationRepository { get; set; }
        IVideoRepository VideoRepository { get; set; }
        IVisionRepository VisionRepository { get; set; }
    }
}
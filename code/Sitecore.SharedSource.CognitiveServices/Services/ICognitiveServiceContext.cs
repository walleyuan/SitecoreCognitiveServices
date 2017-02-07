using Sitecore.SharedSource.CognitiveServices.Services.Knowledge;
using Sitecore.SharedSource.CognitiveServices.Services.Language;
using Sitecore.SharedSource.CognitiveServices.Services.Speech;
using Sitecore.SharedSource.CognitiveServices.Services.Video;
using Sitecore.SharedSource.CognitiveServices.Services.Vision;

namespace Sitecore.SharedSource.CognitiveServices.Services
{
    public interface ICognitiveServiceContext
    {
        IEmotionService EmotionService { get; set; }
        IEntityLinkingService EntityLinkingService { get; set; }
        IFaceService FaceService { get; set; }
        ILanguageService LanguageService { get; set; }
        ILinguisticService LinguisticService { get; set; }
        ISentimentService SentimentService { get; set; }
        ISpeakerIdentificationService SpeakerIdentificationService { get; set; }
        ISpeakerVerificationService SpeakerVerificationService { get; set; }
        IVideoService VideoService { get; set; }
        IVisionService VisionService { get; set; }
    }
}
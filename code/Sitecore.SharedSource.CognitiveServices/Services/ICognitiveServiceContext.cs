using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.SharedSource.CognitiveServices.Services
{
    public interface ICognitiveServiceContext
    {
        IEmotionService EmotionService { get; set; }
        IEntityLinkingService EntityLinkingService { get; set; }
        IFaceService FaceService { get; set; }
        ILanguageService LanguageService { get; set; }
        ISentimentService SentimentService { get; set; }
        ISpeakerIdentificationService SpeakerIdentificationService { get; set; }
        ISpeakerVerificationService SpeakerVerificationService { get; set; }
        IVideoService VideoService { get; set; }
        IVisionService VisionService { get; set; }
    }
}
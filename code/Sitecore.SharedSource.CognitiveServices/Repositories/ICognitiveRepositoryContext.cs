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
    public interface ICognitiveRepositoryContext
    {
        IEmotionApi EmotionApi { get; set; }
        IEntityLinkingApi EntityLinkingApi { get; set; }
        IFaceApi FaceApi { get; set; }
        ILanguageApi LanguageApi { get; set; }
        ISentimentApi SentimentApi { get; set; }
        ISpeakerIdentificationApi SpeakerIdentificationApi { get; set; }
        ISpeakerVerificationApi SpeakerVerificationApi { get; set; }
        IVideoApi VideoApi { get; set; }
        IVisionApi VisionApi { get; set; }
    }
}
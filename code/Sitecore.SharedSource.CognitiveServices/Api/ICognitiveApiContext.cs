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
    public interface ICognitiveApiContext
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ProjectOxford.SpeakerRecognition.Contract.Identification;
using Microsoft.ProjectOxford.Video;
using Sitecore.SharedSource.CognitiveServices.Services.Common;

namespace Sitecore.SharedSource.CognitiveServices.Services.Video
{
    public class VideoApi : VideoServiceClient, IVideoApi
    {
        public VideoApi(
            IApiKeys apiKeys)
            : base(apiKeys.Video)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ProjectOxford.SpeakerRecognition.Contract.Identification;
using Microsoft.ProjectOxford.Video;

namespace Sitecore.SharedSource.CognitiveServices.Repositories.Video
{
    public class VideoRepository : VideoServiceClient, IVideoRepository
    {
        public VideoRepository(IApiKeys apiKeys) : base(apiKeys.Video)
        {
        }
    }
}

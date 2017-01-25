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

using Microsoft.ProjectOxford.Video;

namespace Sitecore.SharedSource.CognitiveServices.Repositories.Vision
{
    public class VideoRepository : VideoServiceClient, IVideoRepository
    {
        public VideoRepository(IApiKeys apiKeys) : base(apiKeys.Video)
        {
        }
    }
}

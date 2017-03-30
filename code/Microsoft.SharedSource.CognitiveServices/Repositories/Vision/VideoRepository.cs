using Microsoft.ProjectOxford.Video;

namespace Microsoft.SharedSource.CognitiveServices.Repositories.Vision
{
    public class VideoRepository : VideoServiceClient, IVideoRepository
    {
        public VideoRepository(IApiKeys apiKeys) : base(apiKeys.Video)
        {
        }
    }
}

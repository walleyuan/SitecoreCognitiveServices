using Microsoft.ProjectOxford.Face;

namespace Sitecore.SharedSource.CognitiveServices.Repositories.Vision
{
    public class FaceRepository : FaceServiceClient, IFaceRepository
    {
        public FaceRepository(
            IApiKeys apiKeys) : base(apiKeys.Face)
        {
        }
    }
}

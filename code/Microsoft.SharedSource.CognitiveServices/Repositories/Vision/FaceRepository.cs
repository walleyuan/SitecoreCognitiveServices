using Microsoft.ProjectOxford.Face;

namespace Microsoft.SharedSource.CognitiveServices.Repositories.Vision
{
    public class FaceRepository : FaceServiceClient, IFaceRepository
    {
        public FaceRepository(
            IApiKeys apiKeys) : base(apiKeys.Face)
        {
        }
    }
}

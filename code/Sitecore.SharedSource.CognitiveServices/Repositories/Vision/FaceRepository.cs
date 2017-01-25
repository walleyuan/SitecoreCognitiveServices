using Microsoft.ProjectOxford.Face;
using Sitecore.SharedSource.CognitiveServices.Services;

namespace Sitecore.SharedSource.CognitiveServices.Repositories.Vision
{
    public class FaceRepository : FaceServiceClient, IFaceRepository
    {
        public IApiService ApiService;

        public FaceRepository(
            IApiKeys apiKeys,
            IApiService apiService) : base(apiKeys.Face)
        {
            ApiService = apiService;
        }
    }
}

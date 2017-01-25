using Sitecore.SharedSource.CognitiveServices.Repositories.Vision;

namespace Sitecore.SharedSource.CognitiveServices.Services.Vision
{
    public class FaceService : IFaceService
    {
        public IFaceRepository FaceRepository;

        public FaceService(IFaceRepository faceRepository)
        {
        }
    }
}
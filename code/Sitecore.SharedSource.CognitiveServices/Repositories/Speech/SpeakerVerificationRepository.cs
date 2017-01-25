using Microsoft.ProjectOxford.SpeakerRecognition;

namespace Sitecore.SharedSource.CognitiveServices.Repositories.Speech
{
    public class SpeakerVerificationRepository : SpeakerVerificationServiceClient, ISpeakerVerificationRepository
    {
        public SpeakerVerificationRepository(
            IApiKeys apiKeys)
            : base(apiKeys.SpeakerRecognition)
        {
        }
    }
}

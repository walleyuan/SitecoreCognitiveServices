using Microsoft.ProjectOxford.SpeakerRecognition;

namespace Microsoft.SharedSource.CognitiveServices.Repositories.Speech
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

using Microsoft.ProjectOxford.SpeakerRecognition;

namespace Microsoft.SharedSource.CognitiveServices.Repositories.Speech
{
    public class SpeakerIdentificationRepository : SpeakerIdentificationServiceClient, ISpeakerIdentificationRepository
    {
        public SpeakerIdentificationRepository(
            IApiKeys apiKeys)
            : base(apiKeys.SpeakerRecognition)
        {
        }
    }
}

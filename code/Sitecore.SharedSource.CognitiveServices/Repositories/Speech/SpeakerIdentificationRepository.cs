using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ProjectOxford.SpeakerRecognition;

namespace Sitecore.SharedSource.CognitiveServices.Repositories.Speech
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ProjectOxford.SpeakerRecognition;

namespace Sitecore.SharedSource.CognitiveServices.Api.Speech
{
    public class SpeakerVerificationApi : SpeakerVerificationServiceClient, ISpeakerVerificationApi
    {
        public SpeakerVerificationApi(
            IApiKeys apiKeys)
            : base(apiKeys.SpeakerRecognition)
        {
        }
    }
}

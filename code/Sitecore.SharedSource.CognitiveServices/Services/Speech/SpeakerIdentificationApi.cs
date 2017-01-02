using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ProjectOxford.SpeakerRecognition;

namespace Sitecore.SharedSource.CognitiveServices.Services.Speech
{
    public class SpeakerIdentificationApi : SpeakerIdentificationServiceClient, ISpeakerIdentificationApi
    {
        public SpeakerIdentificationApi(
            IApiKeys apiKeys)
            : base(apiKeys.SpeakerRecognition)
        {
        }
    }
}

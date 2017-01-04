using System.IO;
using System.Threading.Tasks;
using Microsoft.ProjectOxford.Emotion;
using Microsoft.ProjectOxford.Emotion.Contract;
using Sitecore.Diagnostics;
using Sitecore.Data.Items;

namespace Sitecore.SharedSource.CognitiveServices.Repository.Vision
{
    public class EmotionApi : EmotionServiceClient, IEmotionApi
    {
        public EmotionApi(IApiKeys apiKeys) : base(apiKeys.Emotion)
        {
        }
    }
}

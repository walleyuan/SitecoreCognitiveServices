using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ProjectOxford.Text.Sentiment;

namespace Sitecore.SharedSource.CognitiveServices.Services.Language
{
    public class SentimentApi : SentimentClient, ISentimentApi
    {
        public SentimentApi(
            IApiKeys apiKeys)
            : base(apiKeys.LinguisticAnalysis)
        {
        }
    }
}

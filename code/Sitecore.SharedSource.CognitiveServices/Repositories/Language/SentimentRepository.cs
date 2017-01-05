using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ProjectOxford.Text.Sentiment;

namespace Sitecore.SharedSource.CognitiveServices.Repositories.Language
{
    public class SentimentRepository : SentimentClient, ISentimentRepository
    {
        public SentimentRepository(
            IApiKeys apiKeys)
            : base(apiKeys.LinguisticAnalysis)
        {
        }
    }
}

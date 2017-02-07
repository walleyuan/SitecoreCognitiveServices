using System.Threading.Tasks;
using Microsoft.ProjectOxford.Text.Sentiment;
using Newtonsoft.Json;

namespace Sitecore.SharedSource.CognitiveServices.Repositories.Language
{
    public class SentimentRepository : SentimentClient, ISentimentRepository
    {
        protected static readonly string keyPhraseUrl = "https://westus.api.cognitive.microsoft.com/text/analytics/v2.0/keyPhrases";

        public SentimentRepository(
            IApiKeys apiKeys)
            : base(apiKeys.TextAnalytics)
        {
        }

        public KeyPhraseSentimentResponse GetKeyPhrases(SentimentRequest request)
        {
            return this.GetKeyPhrasesAsync(request).Result;
        }

        public async Task<KeyPhraseSentimentResponse> GetKeyPhrasesAsync(SentimentRequest request)
        {
            request.Validate();
            return JsonConvert.DeserializeObject<KeyPhraseSentimentResponse>(await this.SendPostAsync(keyPhraseUrl, JsonConvert.SerializeObject((object)request)));
        }
    }
}

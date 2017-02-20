using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ProjectOxford.Text.Sentiment;
using Microsoft.ProjectOxford.Video.Contract;
using Newtonsoft.Json;
using Sitecore.SharedSource.CognitiveServices.Models;

namespace Sitecore.SharedSource.CognitiveServices.Repositories.Language
{
    public class SentimentRepository : SentimentClient, ISentimentRepository
    {
        protected static readonly string keyPhraseUrl = "https://westus.api.cognitive.microsoft.com/text/analytics/v2.0/keyPhrases";
        protected static readonly string topicUrl = "https://westus.api.cognitive.microsoft.com/text/analytics/v2.0/topics";
        
        public SentimentRepository(
            IApiKeys apiKeys)
            : base(apiKeys.TextAnalytics)
        {
        }

        public KeyPhraseSentimentResponse GetKeyPhrases(SentimentRequest request)
        {
            return Task.Run(async () => await GetKeyPhrasesAsync(request)).Result;
        }

        public async Task<KeyPhraseSentimentResponse> GetKeyPhrasesAsync(SentimentRequest request)
        {
            request.Validate();
            return JsonConvert.DeserializeObject<KeyPhraseSentimentResponse>(await this.SendPostAsync(keyPhraseUrl, JsonConvert.SerializeObject((object)request)));
        }
        
        /// <summary>
        /// This takes in at least 100 documents and returns a url to the operation where you check for the status of the result
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public string GetTopics(TopicRequest request) 
        {
            return Task.Run(async () => await this.SendTopicsPostAsync(topicUrl, JsonConvert.SerializeObject((object)request))).Result;
        }

        protected async Task<string> SendTopicsPostAsync(string url, string data) {
            if (string.IsNullOrWhiteSpace(url))
                throw new ArgumentException("url");
            if (string.IsNullOrWhiteSpace(this.ApiKey))
                throw new ArgumentException("ApiKey");
            if (string.IsNullOrWhiteSpace(data))
                throw new ArgumentException("data");
            byte[] reqData = Encoding.UTF8.GetBytes(data);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Headers.Add("Ocp-Apim-Subscription-Key", this.ApiKey);
            request.ContentType = "application/json";
            request.Accept = "application/json";
            request.ContentLength = (long)reqData.Length;
            request.Method = "POST";
            Stream requestStreamAsync = await request.GetRequestStreamAsync();
            byte[] buffer = reqData;
            int offset = 0;
            int length = reqData.Length;
            requestStreamAsync.Write(buffer, offset, length);
            requestStreamAsync.Close();
            HttpWebResponse responseAsync = (HttpWebResponse)await request.GetResponseAsync();
            var opLocation = responseAsync.GetResponseHeader("operation-location");
            responseAsync.Close();
            return opLocation;
        }

        public OperationResult GetOperation(string operationLocationUrl)
        {
            return Task.Run(async () => await GetOperationAsync(operationLocationUrl)).Result;
        }

        /// <summary>
        /// This will return the status and result of the GetTopics operation
        /// </summary>
        /// <param name="operationLocationUrl"></param>
        /// <returns></returns>
        public async Task<OperationResult> GetOperationAsync(string operationLocationUrl)
        {
            return JsonConvert.DeserializeObject<OperationResult>(await this.SendPostAsync(operationLocationUrl, "{}"));
        }
    }
}

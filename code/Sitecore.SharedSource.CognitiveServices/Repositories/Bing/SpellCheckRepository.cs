using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.ProjectOxford.Text.Core;
using Newtonsoft.Json;
using Sitecore.SharedSource.CognitiveServices.Enums;
using Sitecore.SharedSource.CognitiveServices.Models.Bing;

namespace Sitecore.SharedSource.CognitiveServices.Repositories.Bing {
    public class SpellCheckRepository : TextClient, ISpellCheckRepository
    {
        public static readonly string spellCheckUrl = "https://api.cognitive.microsoft.com/bing/v5.0/spellcheck/";

        public SpellCheckRepository(
            IApiKeys apiKeys)
            : base(apiKeys.BingSpellCheck)
        {
        }

        public SpellCheckResponse SpellCheck(string text, SpellCheckModeOptions mode = SpellCheckModeOptions.None, string languageCode = "")
        {
            return Task.Run(async () => await SpellCheckAsync(text, mode, languageCode)).Result;
        }

        public async Task<SpellCheckResponse> SpellCheckAsync(string text, SpellCheckModeOptions mode = SpellCheckModeOptions.None, string languageCode = "")
        {
            StringBuilder sb = new StringBuilder();
            if (mode != SpellCheckModeOptions.None)
                sb.Append($"?mode={Enum.GetName(typeof(SpellCheckModeOptions), mode)}");

            if (!string.IsNullOrEmpty(languageCode))
            {
                var concat = (sb.Length > 0) ? "?" : "&";
                sb.Append($"{concat}mkt={languageCode}");
            }
                    
            var response = await this.SendEncodedFormPostAsync($"{spellCheckUrl}{sb}", $"Text={text}");

            return JsonConvert.DeserializeObject<SpellCheckResponse>(response);
        }

        protected async Task<string> SendEncodedFormPostAsync(string url, string data)
        {
            if (string.IsNullOrWhiteSpace(url))
                throw new ArgumentException("url");
            if (string.IsNullOrWhiteSpace(this.ApiKey))
                throw new ArgumentException("ApiKey");
            if (string.IsNullOrWhiteSpace(data))
                throw new ArgumentException("data");

            byte[] reqData = Encoding.UTF8.GetBytes(data);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Headers.Add("Ocp-Apim-Subscription-Key", this.ApiKey);
            request.ContentType = "application/x-www-form-urlencoded";
            request.Accept = "application/x-www-form-urlencoded";
            request.ContentLength = (long)reqData.Length;
            request.Method = "POST";

            Stream requestStreamAsync = await request.GetRequestStreamAsync();
            requestStreamAsync.Write(reqData, 0, reqData.Length);
            requestStreamAsync.Close();

            WebResponse responseAsync = await request.GetResponseAsync();
            StreamReader streamReader = new StreamReader(responseAsync.GetResponseStream());
            string end = streamReader.ReadToEnd();
            streamReader.Close();
            responseAsync.Close();

            return end;
        }
    }
}
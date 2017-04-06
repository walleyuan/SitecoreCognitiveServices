using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Threading;
using System.Net.Http;
using System.Media;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Linq;
using Microsoft.SharedSource.CognitiveServices.Enums;
using Microsoft.SharedSource.CognitiveServices.Models.Bing.Speech;
using Newtonsoft.Json;

namespace Microsoft.SharedSource.CognitiveServices.Repositories.Bing {
    public class SpeechRepository : ISpeechRepository {

        protected readonly IApiKeys ApiKeys;
        protected readonly IRepositoryClient RepositoryClient;

        public SpeechRepository(
            IApiKeys apiKeys,
            IRepositoryClient repositoryClient) {
            ApiKeys = apiKeys;
            RepositoryClient = repositoryClient;
        }
        
        /// <summary>
        /// This transcribes voice queries
        /// </summary>
        /// <param name="audioStream">Audio stream</param>
        /// <param name="scenario">The context for performing a recognition.</param>
        /// <param name="locale">Language code of the audio content in IETF RFC 5646. Case does not matter. </param>
        /// <param name="os">Operating system the client is running on. This is an open field but we encourage clients to use it consistently across devices and applications.</param>
        /// <param name="fromDeviceId">A globally unique device identifier of the device making the request.</param>
        /// <param name="maxnbest">Maximum number of results the voice application API should return. The default is 1. The maximum is 5. Example: maxnbest=3</param>
        /// <param name="profanitycheck">Scan the result text for words included in an offensive word list. If found, the word will be delimited by bad word tag. Example: result.profanity=1 (0 means off, 1 means on, default is 1.)</param>
        public virtual async Task<SpeechToTextResponse> SpeechToTextAsync(Stream audioStream, ScenarioOptions scenario, BingSpeechLocaleOptions locale, SpeechOsOptions os, Guid fromDeviceId, int maxnbest = 1, int profanitycheck = 1) {

            string url = $"https://speech.platform.bing.com/recognize?version=3.0&scenarios={scenario}&appid=D4D52672-91D7-4C74-8AD8-42B1D98141A5&requestid={Guid.NewGuid()}&format=json&locale={locale}&device.os={os}&instanceid={fromDeviceId}&maxnbest={maxnbest}&result.profanitymarkup={profanitycheck}";
            string token = RepositoryClient.SendBingSpeechTokenRequest(ApiKeys.BingSpeech);
            string contentType = "audio/wav; samplerate=16000";
            string data = RepositoryClient.GetStreamString(audioStream);

            var response = await RepositoryClient.SendAsync(ApiKeys.BingSpeech, url, data, contentType, "POST", token, true, "speech.platform.bing.com");

            return JsonConvert.DeserializeObject<SpeechToTextResponse>(response);
        }
        
        public virtual async Task<Stream> TextToSpeechAsync(string text, BingSpeechLocaleOptions locale, string voiceName, GenderOptions voiceType, AudioOutputFormatOptions outputFormat) {

            HttpClientHandler handler = new HttpClientHandler() { CookieContainer = new CookieContainer(), UseProxy = false };
            HttpClient client = new HttpClient(handler);

            client.DefaultRequestHeaders.Clear();

            Dictionary<string, string> Headers = new Dictionary<string, string>()
            {
                { "Content-Type", "application/ssml+xml" },
                { "X-Microsoft-OutputFormat", JsonConvert.SerializeObject(outputFormat) },
                { "Authorization", $"Bearer {RepositoryClient.SendBingSpeechTokenRequest(ApiKeys.BingSpeech)}" },
                { "X-Search-AppId", "07D3234E49CE426DAA29772419F436CA" },
                { "X-Search-ClientID", "1ECFAE91408841A480F00935DC390960" },
                { "User-Agent", "TTSClient" }
            };

            foreach (var header in Headers) {
                client.DefaultRequestHeaders.TryAddWithoutValidation(header.Key, header.Value);
            }

            var request = new HttpRequestMessage(HttpMethod.Post, "https://speech.platform.bing.com/synthesize") {
                Content = new StringContent($"<speak version=\"1.0\" xmlns:lang=\"en-US\"><voice xmlns:lang=\"{JsonConvert.SerializeObject(locale)}\" xmlns:gender=\"{JsonConvert.SerializeObject(voiceType)}\" name=\"{voiceName}\">{text}</voice></speak>")
            };

            var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, CancellationToken.None);

            return await response.Content.ReadAsStreamAsync();
        }
    }
}

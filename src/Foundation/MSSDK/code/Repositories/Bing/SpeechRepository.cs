using System;
using System.Threading.Tasks;
using System.IO;
using MicrosoftCognitiveServices.Foundation.MSSDK.Enums;
using MicrosoftCognitiveServices.Foundation.MSSDK.Models.Bing.Speech;
using Newtonsoft.Json;

namespace MicrosoftCognitiveServices.Foundation.MSSDK.Repositories.Bing {
    public class SpeechRepository : ISpeechRepository
    {
        protected static readonly string contentType = "audio/wav; samplerate=16000";
        
        protected readonly IApiKeys ApiKeys;
        protected readonly IRepositoryClient RepositoryClient;

        public SpeechRepository(
            IApiKeys apiKeys,
            IRepositoryClient repositoryClient) {
            ApiKeys = apiKeys;
            RepositoryClient = repositoryClient;
        }

        protected virtual string GetSpeechToTextUrl(ScenarioOptions scenario, BingSpeechLocaleOptions locale, SpeechOsOptions os, Guid fromDeviceId, int maxnbest, int profanitycheck)
        {
            return $"{ApiKeys.BingSpeechEndpoint}recognize?version=3.0&scenarios={scenario}&appid=D4D52672-91D7-4C74-8AD8-42B1D98141A5&requestid={Guid.NewGuid()}&format=json&locale={locale}&device.os={os}&instanceid={fromDeviceId}&maxnbest={maxnbest}&result.profanitymarkup={profanitycheck}";
        }

        public virtual SpeechToTextResponse SpeechToText(Stream audioStream, ScenarioOptions scenario, BingSpeechLocaleOptions locale, SpeechOsOptions os, Guid fromDeviceId, int maxnbest = 1, int profanitycheck = 1)
        {
            string url = GetSpeechToTextUrl(scenario, locale, os, fromDeviceId, maxnbest, profanitycheck);
            string token = RepositoryClient.SendBingSpeechTokenRequest(ApiKeys.BingSpeech);
            byte[] data = RepositoryClient.GetByteArray(audioStream);

            var response = RepositoryClient.Send(ApiKeys.BingSpeech, url, data, contentType, "POST", token, true, "speech.platform.bing.com");

            return JsonConvert.DeserializeObject<SpeechToTextResponse>(response);
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

            string url = GetSpeechToTextUrl(scenario, locale, os, fromDeviceId, maxnbest, profanitycheck);
            string token = RepositoryClient.SendBingSpeechTokenRequest(ApiKeys.BingSpeech);
            byte[] data = RepositoryClient.GetByteArray(audioStream);

            var response = await RepositoryClient.SendAsync(ApiKeys.BingSpeech, url, data, contentType, "POST", token, true, "speech.platform.bing.com");

            return JsonConvert.DeserializeObject<SpeechToTextResponse>(response);
        }

        public virtual Stream TextToSpeech(string text, BingSpeechLocaleOptions locale, string voiceName, GenderOptions voiceType, AudioOutputFormatOptions outputFormat) {
            var response = Task.Run(async() => await RepositoryClient.GetAudioStreamAsync(
                $"{ApiKeys.BingSpeechEndpoint}synthesize",
                text,
                locale,
                voiceName,
                voiceType,
                outputFormat,
                RepositoryClient.SendBingSpeechTokenRequest(ApiKeys.BingSpeech))).Result;

            return response;
        }

        public virtual async Task<Stream> TextToSpeechAsync(string text, BingSpeechLocaleOptions locale, string voiceName, GenderOptions voiceType, AudioOutputFormatOptions outputFormat)
        {
            var response = await RepositoryClient.GetAudioStreamAsync(
                $"{ApiKeys.BingSpeechEndpoint}synthesize", 
                text, 
                locale, 
                voiceName, 
                voiceType, 
                outputFormat, 
                RepositoryClient.SendBingSpeechTokenRequest(ApiKeys.BingSpeech));
            
            return response;
        }
    }
}

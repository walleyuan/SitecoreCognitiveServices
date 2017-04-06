using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.SharedSource.CognitiveServices.Enums;
using Microsoft.SharedSource.CognitiveServices.Models.Bing.Speech;
using Microsoft.SharedSource.CognitiveServices.Repositories.Bing;
using Sitecore.SharedSource.CognitiveServices.Foundation;

namespace Sitecore.SharedSource.CognitiveServices.Services.Bing {
    public class SpeechService : ISpeechService {

        protected ISpeechRepository SpeechRepository;
        protected ILogWrapper Logger;

        public SpeechService(
            ISpeechRepository speechRepository,
            ILogWrapper logger) {
            SpeechRepository = speechRepository;
            Logger = logger;
        }

        public virtual SpeechToTextResponse SpeechToText(Stream audioStream, ScenarioOptions scenario, BingSpeechLocaleOptions locale, SpeechOsOptions os, Guid fromDeviceId, int maxnbest = 1, int profanitycheck = 1)
        {
            try {
                var result = Task.Run(async () => await SpeechRepository.SpeechToTextAsync(audioStream, scenario, locale, os, fromDeviceId, maxnbest, profanitycheck)).Result;

                return result;
            } catch (Exception ex) {
                Logger.Error("SpeechService.SpeechToText failed", this, ex);
            }

            return null;
        }

        public virtual Stream TextToSpeech(string text, BingSpeechLocaleOptions locale, string voiceName, GenderOptions voiceType, AudioOutputFormatOptions outputFormat)
        {
            try {
                var result = Task.Run(async () => await SpeechRepository.TextToSpeechAsync(text, locale, voiceName, voiceType, outputFormat)).Result;

                return result;
            } catch (Exception ex) {
                Logger.Error("SpeechService.TextToSpeech failed", this, ex);
            }

            return null;
        }
    }
}
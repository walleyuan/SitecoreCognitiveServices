using System;
using System.IO;
using SitecoreCognitiveServices.Foundation.MSSDK.Enums;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Bing.Speech;
using SitecoreCognitiveServices.Foundation.MSSDK.Repositories.Bing;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.MSSDK.Bing {
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
                var result = SpeechRepository.SpeechToText(audioStream, scenario, locale, os, fromDeviceId, maxnbest, profanitycheck);

                return result;
            } catch (Exception ex) {
                Logger.Error("SpeechService.SpeechToText failed", this, ex);
            }

            return null;
        }

        public virtual Stream TextToSpeech(string text, BingSpeechLocaleOptions locale, string voiceName, GenderOptions voiceType, AudioOutputFormatOptions outputFormat)
        {
            try {
                var result = SpeechRepository.TextToSpeech(text, locale, voiceName, voiceType, outputFormat);

                return result;
            } catch (Exception ex) {
                Logger.Error("SpeechService.TextToSpeech failed", this, ex);
            }

            return null;
        }
    }
}
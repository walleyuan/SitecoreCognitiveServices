using System;
using System.IO;
using System.Threading.Tasks;
using SitecoreCognitiveServices.Foundation.MSSDK.Enums;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Bing.Speech;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Repositories.Bing {
    public interface ISpeechRepository {
        SpeechToTextResponse SpeechToText(Stream audioStream, ScenarioOptions scenario, BingSpeechLocaleOptions locale, SpeechOsOptions os, Guid fromDeviceId, int maxnbest = 1, int profanitycheck = 1);
        Task<SpeechToTextResponse> SpeechToTextAsync(Stream audioStream, ScenarioOptions scenario, BingSpeechLocaleOptions locale, SpeechOsOptions os, Guid fromDeviceId, int maxnbest = 1, int profanitycheck = 1);
        Stream TextToSpeech(string text, BingSpeechLocaleOptions locale, string voiceName, GenderOptions voiceType, AudioOutputFormatOptions outputFormat);
        Task<Stream> TextToSpeechAsync(string text, BingSpeechLocaleOptions locale, string voiceName, GenderOptions voiceType, AudioOutputFormatOptions outputFormat);
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.SharedSource.CognitiveServices.Enums;
using Microsoft.SharedSource.CognitiveServices.Models.Bing.Speech;

namespace Microsoft.SharedSource.CognitiveServices.Repositories.Bing {
    public interface ISpeechRepository {
        SpeechToTextResponse SpeechToText(Stream audioStream, ScenarioOptions scenario, BingSpeechLocaleOptions locale, SpeechOsOptions os, Guid fromDeviceId, int maxnbest = 1, int profanitycheck = 1);
        Task<SpeechToTextResponse> SpeechToTextAsync(Stream audioStream, ScenarioOptions scenario, BingSpeechLocaleOptions locale, SpeechOsOptions os, Guid fromDeviceId, int maxnbest = 1, int profanitycheck = 1);
        Task<Stream> TextToSpeechAsync(string text, BingSpeechLocaleOptions locale, string voiceName, GenderOptions voiceType, AudioOutputFormatOptions outputFormat);
    }
}
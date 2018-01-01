using System;
using System.IO;
using SitecoreCognitiveServices.Foundation.MSSDK;
using SitecoreCognitiveServices.Foundation.MSSDK.Enums;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Bing.Speech;
using SitecoreCognitiveServices.Foundation.MSSDK.Repositories.Bing;
using SitecoreCognitiveServices.Foundation.SCSDK.Policies;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.MSSDK.Bing {
    public class SpeechService : ISpeechService {

        protected readonly IMicrosoftCognitiveServicesApiKeys ApiKeys;
        protected readonly IMSSDKPolicyService PolicyService;
        protected readonly ISpeechRepository SpeechRepository;
        protected readonly ILogWrapper Logger;

        public SpeechService(
            IMicrosoftCognitiveServicesApiKeys apiKeys,
            IMSSDKPolicyService policyService,
            ISpeechRepository speechRepository,
            ILogWrapper logger)
        {
            ApiKeys = apiKeys;
            PolicyService = policyService;
            SpeechRepository = speechRepository;
            Logger = logger;
        }

        public virtual SpeechToTextResponse SpeechToText(Stream audioStream, ScenarioOptions scenario, BingSpeechLocaleOptions locale, SpeechOsOptions os, Guid fromDeviceId, int maxnbest = 1, int profanitycheck = 1)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "SpeechService.SpeechToText",
                ApiKeys.BingSpeechRetryInSeconds,
                () =>
                {
                    var result = SpeechRepository.SpeechToText(audioStream, scenario, locale, os, fromDeviceId, maxnbest, profanitycheck);
                    return result;
                },
                null);
        }

        public virtual Stream TextToSpeech(string text, BingSpeechLocaleOptions locale, string voiceName, GenderOptions voiceType, AudioOutputFormatOptions outputFormat)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "SpeechService.TextToSpeech",
                ApiKeys.BingSpeechRetryInSeconds,
                () =>
                {
                    var result = SpeechRepository.TextToSpeech(text, locale, voiceName, voiceType, outputFormat);
                    return result;
                },
                null);
        }
    }
}
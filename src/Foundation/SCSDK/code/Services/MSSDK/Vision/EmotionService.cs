using System;
using System.Collections.Generic;
using System.IO;
using Polly;
using SitecoreCognitiveServices.Foundation.MSSDK;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;
using SitecoreCognitiveServices.Foundation.MSSDK.Repositories.Vision;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Vision.Emotion;
using SitecoreCognitiveServices.Foundation.SCSDK.Policies;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.MSSDK.Vision
{
    public class EmotionService : IEmotionService
    {
        protected readonly IMicrosoftCognitiveServicesApiKeys ApiKeys;
        protected readonly IMSSDKPolicyService PolicyService;
        protected readonly IEmotionRepository EmotionRepository;
        protected readonly ILogWrapper Logger;

        public EmotionService(
            IMicrosoftCognitiveServicesApiKeys apiKeys,
            IMSSDKPolicyService policyService,
            IEmotionRepository emotionRepository,
            ILogWrapper logger)
        {
            ApiKeys = apiKeys;
            PolicyService = policyService;
            EmotionRepository = emotionRepository;
            Logger = logger;
        }

        public virtual Emotion[] Recognize(Stream stream)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "EmotionService.Recognize",
                ApiKeys.EmotionRetryInSeconds,
                () => 
                {
                    var result = EmotionRepository.Recognize(stream);
                    return result;
                },
                null);
        }

        public virtual Emotion[] Recognize(string imageUrl) {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "EmotionService.Recognize",
                ApiKeys.EmotionRetryInSeconds,
                () =>
                {
                    var result = EmotionRepository.Recognize(imageUrl);
                    return result;
                },
                null);
        }
    }
}
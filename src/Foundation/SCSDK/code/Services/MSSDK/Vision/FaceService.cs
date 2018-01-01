using System;
using System.Collections.Generic;
using System.IO;
using SitecoreCognitiveServices.Foundation.MSSDK;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;
using SitecoreCognitiveServices.Foundation.MSSDK.Repositories.Vision;
using SitecoreCognitiveServices.Foundation.MSSDK.Enums;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Vision.Face;
using SitecoreCognitiveServices.Foundation.SCSDK.Policies;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.MSSDK.Vision
{
    public class FaceService : IFaceService
    {
        protected readonly IMicrosoftCognitiveServicesApiKeys ApiKeys;
        protected readonly IMSSDKPolicyService PolicyService;
        protected readonly IFaceRepository FaceRepository;
        protected readonly ILogWrapper Logger;

        public FaceService(
            IMicrosoftCognitiveServicesApiKeys apiKeys,
            IMSSDKPolicyService policyService,
            IFaceRepository faceRepository,
            ILogWrapper logger)
        {
            ApiKeys = apiKeys;
            PolicyService = policyService;
            FaceRepository = faceRepository;
            Logger = logger;
        }

        public virtual Face[] Detect(Stream stream, bool returnFaceId = true, bool returnFaceLandmarks = false, IEnumerable<FaceAttributeType> returnFaceAttributes = null)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "FaceService.Detect",
                ApiKeys.FaceRetryInSeconds,
                () =>
                {
                    var result = FaceRepository.Detect(stream, returnFaceId, returnFaceLandmarks, returnFaceAttributes);
                    return result;
                },
                null);
        }

        public virtual Face[] Detect(string imageUrl, bool returnFaceId = true, bool returnFaceLandmarks = false, IEnumerable<FaceAttributeType> returnFaceAttributes = null)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "FaceService.Detect",
                ApiKeys.FaceRetryInSeconds,
                () =>
                {
                    var result = FaceRepository.Detect(imageUrl, returnFaceId, returnFaceLandmarks, returnFaceAttributes);
                    return result;
                },
                null);
        }
    }
}
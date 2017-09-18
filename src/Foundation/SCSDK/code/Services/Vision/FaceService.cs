using System;
using System.Collections.Generic;
using System.IO;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;
using MicrosoftCognitiveServices.Foundation.MSSDK.Repositories.Vision;
using MicrosoftCognitiveServices.Foundation.MSSDK.Enums;
using MicrosoftCognitiveServices.Foundation.MSSDK.Models.Vision.Face;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.Vision
{
    public class FaceService : IFaceService
    {
        protected IFaceRepository FaceRepository;
        protected ILogWrapper Logger;

        public FaceService(
            IFaceRepository faceRepository,
            ILogWrapper logger)
        {
            FaceRepository = faceRepository;
            Logger = logger;
        }

        public virtual Face[] Detect(Stream stream, bool returnFaceId = true, bool returnFaceLandmarks = false, IEnumerable<FaceAttributeType> returnFaceAttributes = null)
        {
            try
            {
                var result = FaceRepository.Detect(stream, returnFaceId, returnFaceLandmarks, returnFaceAttributes);

                return result;
            } 
            catch (Exception ex) 
            {
                Logger.Error("FaceService.Detect failed", this, ex);
            }

            return null;
        }

        public virtual Face[] Detect(string imageUrl, bool returnFaceId = true, bool returnFaceLandmarks = false, IEnumerable<FaceAttributeType> returnFaceAttributes = null) {
            try {
                var result = FaceRepository.Detect(imageUrl, returnFaceId, returnFaceLandmarks, returnFaceAttributes);

                return result;
            } catch (Exception ex) {
                Logger.Error("FaceService.Detect failed", this, ex);
            }

            return null;
        }
    }
}
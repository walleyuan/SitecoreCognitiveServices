using System;
using System.Collections.Generic;
using System.IO;
using Sitecore.SharedSource.CognitiveServices.Wrappers;
using Microsoft.SharedSource.CognitiveServices.Repositories.Vision;
using Microsoft.SharedSource.CognitiveServices.Enums;
using Microsoft.SharedSource.CognitiveServices.Models.Vision.Face;

namespace Sitecore.SharedSource.CognitiveServices.Services.Vision
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
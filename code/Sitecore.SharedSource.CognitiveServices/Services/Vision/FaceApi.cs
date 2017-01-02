using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ProjectOxford.Face;
using Microsoft.ProjectOxford.Face.Contract;
using Sitecore.Data.Items;
using Sitecore.SharedSource.CognitiveServices.Services.Common;
using Sitecore.Diagnostics;

namespace Sitecore.SharedSource.CognitiveServices.Services.Vision
{
    public class FaceApi : FaceServiceClient, IFaceApi
    {
        public IServiceUtil ServiceUtil;
        
        public FaceApi(
            IApiKeys apiKeys,
            IServiceUtil serviceUtil)
            : base(apiKeys.Face)
        {
            ServiceUtil = serviceUtil;
        }

        public virtual Task<AddPersistedFaceResult> AddFaceToFaceListAsync(string faceListId, MediaItem mediaItem, string userData = null, FaceRectangle targetFace = null)
        {
            Assert.IsNotNullOrEmpty(faceListId, "AddFaceToFaceListAsync: faceListId must be provided but was empty");
            Assert.IsNotNull(mediaItem, GetType());
            
            using (MemoryStream stream = ServiceUtil.GetStream(mediaItem))
            {
                return AddFaceToFaceListAsync(faceListId, stream, userData, targetFace);
            }
        }

        public virtual Task<AddPersistedFaceResult> AddPersonFaceAsync(string personGroupId, Guid personId, MediaItem mediaItem, string userData = null, FaceRectangle targetFace = null)
        {
            Assert.IsNotNullOrEmpty(personGroupId, "AddFaceToFaceListAsync: personGroupId must be provided but was empty");
            Assert.IsNotNull(personId, GetType());
            Assert.IsNotNull(mediaItem, GetType());

            using (MemoryStream stream = ServiceUtil.GetStream(mediaItem))
            {
                return AddPersonFaceAsync(personGroupId, personId, stream, userData, targetFace);
            }
        }

        public virtual Task<Microsoft.ProjectOxford.Face.Contract.Face[]> DetectAsync(MediaItem mediaItem, bool returnFaceId = true, bool returnFaceLandmarks = false, IEnumerable<FaceAttributeType> returnFaceAttributes = null)
        {
            Assert.IsNotNull(mediaItem, GetType());

            using (MemoryStream stream = ServiceUtil.GetStream(mediaItem))
            {
                return DetectAsync(stream, returnFaceId, returnFaceLandmarks, returnFaceAttributes);
            }
        }
    }
}

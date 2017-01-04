using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.ProjectOxford.Face;
using Microsoft.ProjectOxford.Face.Contract;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.SharedSource.CognitiveServices.Api.Vision;

namespace Sitecore.SharedSource.CognitiveServices.Services
{
    public class FaceService : IFaceService
    {
        public IFaceApi FaceApi;
        public IApiService ApiService;

        public FaceService(
            IFaceApi faceApi,
            IApiService apiService)
        {
            FaceApi = faceApi;
            ApiService = apiService;
        }

        public virtual Task<AddPersistedFaceResult> AddFaceToFaceListAsync(string faceListId, MediaItem mediaItem, string userData = null, FaceRectangle targetFace = null)
        {
            Assert.IsNotNullOrEmpty(faceListId, "AddFaceToFaceListAsync: faceListId must be provided but was empty");
            Assert.IsNotNull(mediaItem, GetType());

            using (MemoryStream stream = ApiService.GetStream(mediaItem))
            {
                return FaceApi.AddFaceToFaceListAsync(faceListId, stream, userData, targetFace);
            }
        }

        public virtual Task<AddPersistedFaceResult> AddPersonFaceAsync(string personGroupId, Guid personId, MediaItem mediaItem, string userData = null, FaceRectangle targetFace = null)
        {
            Assert.IsNotNullOrEmpty(personGroupId, "AddFaceToFaceListAsync: personGroupId must be provided but was empty");
            Assert.IsNotNull(personId, GetType());
            Assert.IsNotNull(mediaItem, GetType());

            using (MemoryStream stream = ApiService.GetStream(mediaItem))
            {
                return FaceApi.AddPersonFaceAsync(personGroupId, personId, stream, userData, targetFace);
            }
        }

        public virtual Task<Microsoft.ProjectOxford.Face.Contract.Face[]> DetectAsync(MediaItem mediaItem, bool returnFaceId = true, bool returnFaceLandmarks = false, IEnumerable<FaceAttributeType> returnFaceAttributes = null)
        {
            Assert.IsNotNull(mediaItem, GetType());

            using (MemoryStream stream = ApiService.GetStream(mediaItem))
            {
                return FaceApi.DetectAsync(stream, returnFaceId, returnFaceLandmarks, returnFaceAttributes);
            }
        }
    }
}
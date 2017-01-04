using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.ProjectOxford.Face;
using Microsoft.ProjectOxford.Face.Contract;
using Sitecore.Data.Items;

namespace Sitecore.SharedSource.CognitiveServices.Services
{
    public interface IFaceService
    {
        Task<AddPersistedFaceResult> AddFaceToFaceListAsync(string faceListId, MediaItem mediaItem, string userData = null, FaceRectangle targetFace = null);
        Task<AddPersistedFaceResult> AddPersonFaceAsync(string personGroupId, Guid personId, MediaItem mediaItem, string userData = null, FaceRectangle targetFace = null);
        Task<Microsoft.ProjectOxford.Face.Contract.Face[]> DetectAsync(MediaItem mediaItem, bool returnFaceId = true, bool returnFaceLandmarks = false, IEnumerable<FaceAttributeType> returnFaceAttributes = null);
    }
}
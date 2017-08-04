
using Microsoft.SharedSource.CognitiveServices.Enums;
using Microsoft.SharedSource.CognitiveServices.Models.Vision.Face;
using System.Collections.Generic;
using System.IO;

namespace Sitecore.SharedSource.CognitiveServices.Services.Vision
{
    public interface IFaceService
    {
        Face[] Detect(Stream stream, bool returnFaceId = true, bool returnFaceLandmarks = false, IEnumerable<FaceAttributeType> returnFaceAttributes = null);
        Face[] Detect(string imageUrl, bool returnFaceId = true, bool returnFaceLandmarks = false, IEnumerable<FaceAttributeType> returnFaceAttributes = null);
    }
}
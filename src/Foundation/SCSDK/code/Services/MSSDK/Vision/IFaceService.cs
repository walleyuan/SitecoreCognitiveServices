
using SitecoreCognitiveServices.Foundation.MSSDK.Enums;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Vision.Face;
using System.Collections.Generic;
using System.IO;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.MSSDK.Vision
{
    public interface IFaceService
    {
        Face[] Detect(Stream stream, bool returnFaceId = true, bool returnFaceLandmarks = false, IEnumerable<FaceAttributeType> returnFaceAttributes = null);
        Face[] Detect(string imageUrl, bool returnFaceId = true, bool returnFaceLandmarks = false, IEnumerable<FaceAttributeType> returnFaceAttributes = null);
    }
}
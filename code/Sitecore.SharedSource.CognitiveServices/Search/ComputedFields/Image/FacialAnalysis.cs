using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Microsoft.ProjectOxford.Face;
using Microsoft.ProjectOxford.SpeakerRecognition.Contract.Verification;
using Sitecore.Data.Items;
using Sitecore.SharedSource.CognitiveServices.Foundation;
using Sitecore.SharedSource.CognitiveServices.Services;
using Sitecore.SharedSource.CognitiveServices.Services.Vision;

namespace Sitecore.SharedSource.CognitiveServices.Search.ComputedFields.Image
{
    public class FacialAnalysis : BaseComputedField
    {
        protected override object GetFieldValue(Item indexItem)
        {
            var dataService = DependencyResolver.Current.GetService<ISitecoreDataService>();
            if (dataService == null)
                return string.Empty;

            if (!dataService.IsMediaFile(indexItem))
                return string.Empty;

            MediaItem m = indexItem;

            var faceService = DependencyResolver.Current.GetService<IFaceService>();
            if (faceService == null)
                return string.Empty;
            
            var result = faceService.Detect(m.GetMediaStream(), true, true, new List<FaceAttributeType>()
            {
                FaceAttributeType.Age,
                FaceAttributeType.FacialHair,
                FaceAttributeType.Gender,
                FaceAttributeType.Glasses,
                FaceAttributeType.HeadPose,
                FaceAttributeType.Smile
            });

            if (result == null)
                return string.Empty;
            
            var json = new JavaScriptSerializer().Serialize(result);

            return json;
        }
    }
}
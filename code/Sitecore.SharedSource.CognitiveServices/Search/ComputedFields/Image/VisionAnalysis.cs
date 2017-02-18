using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Microsoft.ProjectOxford.Vision;
using Sitecore.Data.Items;
using Sitecore.SharedSource.CognitiveServices.Foundation;
using Sitecore.SharedSource.CognitiveServices.Services.Vision;

namespace Sitecore.SharedSource.CognitiveServices.Search.ComputedFields.Image
{
    public class VisionAnalysis : BaseComputedField
    {
        protected override object GetFieldValue(Item indexItem)
        {
            var dataService = DependencyResolver.Current.GetService<ISitecoreDataService>();
            if (dataService == null)
                return string.Empty;

            if (!dataService.IsMediaFile(indexItem))
                return string.Empty;

            MediaItem m = indexItem;

            var visionService = DependencyResolver.Current.GetService<IVisionService>();
            if (visionService == null)
                return string.Empty;
            
            var result = visionService.AnalyzeImage(m.GetMediaStream(), new List<VisualFeature>()
            {
                VisualFeature.Adult,
                VisualFeature.Categories,
                VisualFeature.Color,
                VisualFeature.Description,
                VisualFeature.Faces,
                VisualFeature.ImageType,
                VisualFeature.Tags
            });

            if (result == null)
                return string.Empty;
 
            var json = new JavaScriptSerializer().Serialize(result);

            return json;
        }
    }
}
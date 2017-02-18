using System;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Sitecore.Data.Items;
using Sitecore.SharedSource.CognitiveServices.Foundation;
using Sitecore.SharedSource.CognitiveServices.Services.Vision;

namespace Sitecore.SharedSource.CognitiveServices.Search.ComputedFields.Image
{
    public class TextAnalysis : BaseComputedField
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
            
            try {
                var result = visionService.RecognizeText(m.GetMediaStream(), "en", true);
                var json = new JavaScriptSerializer().Serialize(result);

                return json;
            } catch (Exception ex) { LogError(ex, indexItem); }

            return string.Empty;
        }
    }
}
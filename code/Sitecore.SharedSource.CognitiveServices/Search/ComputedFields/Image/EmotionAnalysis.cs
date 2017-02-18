using System.Web.Mvc;
using System.Web.Script.Serialization;
using Sitecore.Data.Items;
using Sitecore.SharedSource.CognitiveServices.Foundation;
using Sitecore.SharedSource.CognitiveServices.Services.Vision;

namespace Sitecore.SharedSource.CognitiveServices.Search.ComputedFields.Image
{
    public class EmotionAnalysis : BaseComputedField
    {
        protected override object GetFieldValue(Item indexItem)
        {
            var dataService = DependencyResolver.Current.GetService<ISitecoreDataService>();
            if (dataService == null)
                return string.Empty;

            if (!dataService.IsMediaFile(indexItem))
                return string.Empty;

            MediaItem m = indexItem;

            var emotionService = DependencyResolver.Current.GetService<IEmotionService>();
            if (emotionService == null)
                return string.Empty;
            
            var result = emotionService.Recognize(m.GetMediaStream());
            if(result == null)
                return string.Empty;
            
            var json = new JavaScriptSerializer().Serialize(result);

            return json;
        }
    }
}
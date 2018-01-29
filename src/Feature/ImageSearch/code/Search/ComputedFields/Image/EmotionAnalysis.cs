using System.Web.Script.Serialization;
using Sitecore.Data.Items;

namespace SitecoreCognitiveServices.Feature.ImageSearch.Search.ComputedFields.Image
{
    public class EmotionAnalysis : BaseComputedField
    {
        protected override object GetFieldValue(Item cognitiveIndexable)
        {
            if (Emotions == null)
                return null;
            
            var json = new JavaScriptSerializer().Serialize(Emotions);
            return json;
        }
    }
}
using System.Web.Script.Serialization;

namespace Sitecore.SharedSource.CognitiveServices.ImageSearch.Search.ComputedFields.Image
{
    public class VisionAnalysis : BaseComputedField
    {
        protected override object GetFieldValue(CognitiveIndexableImageItem cognitiveIndexable)
        {
            if (cognitiveIndexable.Visions == null)
            {
                return null;
            }

            var json = new JavaScriptSerializer().Serialize(cognitiveIndexable.Visions);
            return json;
        }
    }
}
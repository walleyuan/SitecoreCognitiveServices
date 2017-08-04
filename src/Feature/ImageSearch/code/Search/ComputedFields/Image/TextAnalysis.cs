using System.Web.Script.Serialization;

namespace Sitecore.SharedSource.CognitiveServices.ImageSearch.Search.ComputedFields.Image
{
    public class TextAnalysis : BaseComputedField
    {
        protected override object GetFieldValue(CognitiveIndexableImageItem cognitiveIndexable)
        {
            if (cognitiveIndexable.Text == null)
            {
                return null;
            }

            var json = new JavaScriptSerializer().Serialize(cognitiveIndexable.Text);
            return json;
        }
    }
}
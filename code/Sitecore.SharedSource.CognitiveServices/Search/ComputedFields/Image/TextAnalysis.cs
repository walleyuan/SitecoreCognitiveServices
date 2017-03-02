using System.Web.Script.Serialization;

namespace Sitecore.SharedSource.CognitiveServices.Search.ComputedFields.Image
{
    public class TextAnalysis : BaseComputedField
    {
        protected override object GetFieldValue(CognitiveIndexableItem cognitiveIndexable)
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
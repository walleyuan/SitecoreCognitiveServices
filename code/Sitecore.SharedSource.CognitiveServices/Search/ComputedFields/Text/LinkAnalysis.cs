extern alias MicrosoftProjectOxfordCommon;
using System.Web.Script.Serialization;

namespace Sitecore.SharedSource.CognitiveServices.Search.ComputedFields.Text
{
    public class LinkAnalysis : BaseComputedField
    {
        protected override object GetFieldValue(CognitiveIndexableItem cognitiveIndexable)
        {
            if (cognitiveIndexable.EntityLinking == null)
            {
                return null;
            }

            var json = new JavaScriptSerializer().Serialize(cognitiveIndexable.EntityLinking);
            return json;
        }
    }
}
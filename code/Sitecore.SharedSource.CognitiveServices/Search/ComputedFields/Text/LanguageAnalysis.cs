extern alias MicrosoftProjectOxfordCommon;
using System.Web.Script.Serialization;

namespace Sitecore.SharedSource.CognitiveServices.Search.ComputedFields.Text
{
    public class LanguageAnalysis : BaseComputedField
    {
        protected override object GetFieldValue(CognitiveIndexableItem cognitiveIndexable)
        {
            if (cognitiveIndexable.Languages == null)
            {
                return null;
            }

            var json = new JavaScriptSerializer().Serialize(cognitiveIndexable.Languages);
            return json;
        }
    }
}
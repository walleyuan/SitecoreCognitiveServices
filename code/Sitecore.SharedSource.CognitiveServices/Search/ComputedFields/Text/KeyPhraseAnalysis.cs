using System.Web.Script.Serialization;

namespace Sitecore.SharedSource.CognitiveServices.Search.ComputedFields.Text
{
    public class KeyPhraseAnalysis : BaseComputedField
    {
        protected override object GetFieldValue(CognitiveIndexableItem cognitiveIndexable)
        {
            if (cognitiveIndexable.KeyPhraseAnalysis == null)
            {
                return null;
            }

            var json = new JavaScriptSerializer().Serialize(cognitiveIndexable.KeyPhraseAnalysis);
            return json;
        }
    }
}
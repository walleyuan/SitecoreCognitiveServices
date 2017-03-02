using System.Linq;

namespace Sitecore.SharedSource.CognitiveServices.Search.ComputedFields.Image.Adult
{
    public class AdultScore : BaseComputedField
    {
        protected override object GetFieldValue(CognitiveIndexableItem cognitiveIndexable)
        {
            return (cognitiveIndexable.Visions != null && cognitiveIndexable.Visions.Adult != null)
                    ? (object)cognitiveIndexable.Visions.Adult.AdultScore
                    : null;
        }
    }
}
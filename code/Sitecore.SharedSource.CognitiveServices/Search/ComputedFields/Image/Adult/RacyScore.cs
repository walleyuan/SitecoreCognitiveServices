using System.Linq;

namespace Sitecore.SharedSource.CognitiveServices.Search.ComputedFields.Image.Adult
{
    public class RacyScore : BaseComputedField
    {
        protected override object GetFieldValue(CognitiveIndexableItem cognitiveIndexable)
        {
            return (cognitiveIndexable.Visions != null && cognitiveIndexable.Visions.Adult != null)
                    ? (object)cognitiveIndexable.Visions.Adult.RacyScore
                    : null;
        }
    }
}
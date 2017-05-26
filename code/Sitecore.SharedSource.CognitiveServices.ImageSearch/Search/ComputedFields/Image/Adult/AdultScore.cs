using Sitecore.SharedSource.CognitiveServices.Search;
using Sitecore.SharedSource.CognitiveServices.Search.ComputedFields;

namespace Sitecore.SharedSource.CognitiveServices.ImageSearch.Search.ComputedFields.Image.Adult
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
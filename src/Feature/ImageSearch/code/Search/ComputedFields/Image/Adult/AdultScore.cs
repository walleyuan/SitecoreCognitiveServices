
using Sitecore.Data.Items;

namespace SitecoreCognitiveServices.Feature.ImageSearch.Search.ComputedFields.Image.Adult
{
    public class AdultScore : BaseComputedField
    {
        protected override object GetFieldValue(Item cognitiveIndexable)
        {
            return (Visions != null && Visions.Adult != null)
                    ? (object)Visions.Adult.AdultScore
                    : null;
        }
    }
}
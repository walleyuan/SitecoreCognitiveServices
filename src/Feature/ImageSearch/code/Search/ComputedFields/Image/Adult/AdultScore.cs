
namespace Sitecore.SharedSource.CognitiveServices.ImageSearch.Search.ComputedFields.Image.Adult
{
    public class AdultScore : BaseComputedField
    {
        protected override object GetFieldValue(CognitiveIndexableImageItem cognitiveIndexable)
        {
            return (cognitiveIndexable.Visions != null && cognitiveIndexable.Visions.Adult != null)
                    ? (object)cognitiveIndexable.Visions.Adult.AdultScore
                    : null;
        }
    }
}
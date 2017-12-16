
namespace SitecoreCognitiveServices.Feature.ImageSearch.Search.ComputedFields.Image.Adult
{
    public class RacyScore : BaseComputedField
    {
        protected override object GetFieldValue(CognitiveIndexableImageItem cognitiveIndexable)
        {
            return (cognitiveIndexable.Visions != null && cognitiveIndexable.Visions.Adult != null)
                    ? (object)cognitiveIndexable.Visions.Adult.RacyScore
                    : null;
        }
    }
}
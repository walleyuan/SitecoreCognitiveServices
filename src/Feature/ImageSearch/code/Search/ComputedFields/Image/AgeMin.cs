using System.Linq;

namespace Sitecore.SharedSource.CognitiveServices.ImageSearch.Search.ComputedFields.Image
{
    public class AgeMin : BaseComputedField
    {
        protected override object GetFieldValue(CognitiveIndexableImageItem cognitiveIndexable)
        {
            return cognitiveIndexable?.Faces?.Select(x => x.FaceAttributes.Age).OrderBy(a => a).FirstOrDefault() ?? 0d;
        }
    }
}
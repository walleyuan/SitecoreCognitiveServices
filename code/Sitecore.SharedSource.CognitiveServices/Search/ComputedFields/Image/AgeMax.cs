using System.Linq;

namespace Sitecore.SharedSource.CognitiveServices.Search.ComputedFields.Image
{
    public class AgeMax : BaseComputedField
    {
        protected override object GetFieldValue(CognitiveIndexableItem cognitiveIndexable)
        {
            return cognitiveIndexable?.Faces?.Select(x => x.FaceAttributes.Age).OrderByDescending(a => a).FirstOrDefault() ?? 100d;
        }
    }
}
using System.Linq;

namespace Sitecore.SharedSource.CognitiveServices.Search.ComputedFields.Image
{
    public class Age : BaseComputedField
    {
        protected override object GetFieldValue(CognitiveIndexableItem cognitiveIndexable)
        {
            return (cognitiveIndexable.Faces != null && cognitiveIndexable.Faces.Length > 0)
                ? (object)cognitiveIndexable.Faces.Average(x => x.FaceAttributes.Age)
                : null;
        }
    }
}
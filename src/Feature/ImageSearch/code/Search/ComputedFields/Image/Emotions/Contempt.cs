using System.Linq;
using Sitecore.Data.Items;

namespace SitecoreCognitiveServices.Feature.ImageSearch.Search.ComputedFields.Image.Emotions
{
    public class Contempt : BaseComputedField
    {
        protected override object GetFieldValue(Item cognitiveIndexable)
        {
            return (Faces != null && Faces.Length > 0)
                ? (object)Faces?.Average(x => x.FaceAttributes.Emotion.Contempt)
                : null;
        }
    }
}
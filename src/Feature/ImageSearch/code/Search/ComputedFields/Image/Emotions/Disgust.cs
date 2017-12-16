using System.Linq;

namespace SitecoreCognitiveServices.Feature.ImageSearch.Search.ComputedFields.Image.Emotions
{
    public class Disgust : BaseComputedField
    {
        protected override object GetFieldValue(CognitiveIndexableImageItem cognitiveIndexable)
        {
            return (cognitiveIndexable.Emotions != null && cognitiveIndexable.Emotions.Length > 0) 
                ? (object)cognitiveIndexable.Emotions?.Average(x => x.Scores.Disgust)
                : null;
        }
    }
}
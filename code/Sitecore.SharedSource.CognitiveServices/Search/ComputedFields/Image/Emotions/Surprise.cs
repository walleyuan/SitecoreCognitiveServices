using System.Linq;

namespace Sitecore.SharedSource.CognitiveServices.Search.ComputedFields.Image.Emotions
{
    public class Surprise : BaseComputedField
    {
        protected override object GetFieldValue(CognitiveIndexableItem cognitiveIndexable)
        {
            return (cognitiveIndexable.Emotions != null && cognitiveIndexable.Emotions.Length > 0)
                ? (object)cognitiveIndexable.Emotions?.Average(x => x.Scores.Surprise)
                : null;
        }
    }
}
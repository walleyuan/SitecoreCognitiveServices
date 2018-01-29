using System.Linq;
using Sitecore.Data.Items;

namespace SitecoreCognitiveServices.Feature.ImageSearch.Search.ComputedFields.Image
{
    public class AgeMax : BaseComputedField
    {
        protected override object GetFieldValue(Item cognitiveIndexable)
        {
            return Faces?.Select(x => x.FaceAttributes.Age).OrderByDescending(a => a).FirstOrDefault() ?? 100d;
        }
    }
}
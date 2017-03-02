using System.Collections.Generic;
using System.Linq;

namespace Sitecore.SharedSource.CognitiveServices.Search.ComputedFields.Image
{
    public class Glasses : BaseComputedField
    {
        protected override object GetFieldValue(CognitiveIndexableItem cognitiveIndexable)
        {
            if (cognitiveIndexable.Faces == null || cognitiveIndexable.Faces.Length == 0)
            {
                return null;
            }

            List<int> returnValue = cognitiveIndexable.Faces?.Select(x => (int) x.FaceAttributes.Glasses).ToList();
            return returnValue;
        }
    }
}
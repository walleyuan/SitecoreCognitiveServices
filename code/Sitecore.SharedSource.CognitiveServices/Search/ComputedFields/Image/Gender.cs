using System.Linq;

namespace Sitecore.SharedSource.CognitiveServices.Search.ComputedFields.Image
{
    public class Gender : BaseComputedField
    {
        protected override object GetFieldValue(CognitiveIndexableItem cognitiveIndexable)
        {
            if (cognitiveIndexable.Faces == null || cognitiveIndexable.Faces.Length == 0)
            {
                return null;
            }

            if (cognitiveIndexable.Faces.Any(x => x.FaceAttributes.Gender.Equals("male")) && cognitiveIndexable.Faces.Any(x => x.FaceAttributes.Gender.Equals("female")))
            {
                return 2;
            }

            if (cognitiveIndexable.Faces.Any(x => x.FaceAttributes.Gender.Equals("male")))
            {
                return 3;
            }

            if (cognitiveIndexable.Faces.Any(x => x.FaceAttributes.Gender.Equals("female")))
            {
                return 4;
            }

            return 1;
        }
    }
}
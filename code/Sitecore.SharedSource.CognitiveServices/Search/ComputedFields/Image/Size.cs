using Sitecore.Data.Items;
using Microsoft.SharedSource.CognitiveServices.Enums;

namespace Sitecore.SharedSource.CognitiveServices.Search.ComputedFields.Image
{
    public class Size: BaseComputedField
    {
        protected override object GetFieldValue(CognitiveIndexableItem cognitiveIndexable)
        {
            MediaItem mediaItem = new MediaItem(cognitiveIndexable.Item);

            if (string.IsNullOrEmpty(mediaItem.InnerItem["Height"]) ||
                string.IsNullOrEmpty(mediaItem.InnerItem["Width"]))
            {
                return null;
            }

            int height;
            int width;

            if (!int.TryParse(mediaItem.InnerItem["Height"], out height) ||
                !int.TryParse(mediaItem.InnerItem["Width"], out width))
            {
                return null;
            }

            if (height >= 2272 && width >= 1704)
            {
                return (int)ImageSize.Size4Mp;
            }
            if (height >= 1600 && width >= 1200)
            {
                return (int)ImageSize.Size2Mp;
            }
            if (height >= 1024 && width >= 768)
            {
                return (int)ImageSize.Size1024X768;
            }
            if (height >= 800 && width >= 600)
            {
                return (int)ImageSize.Size800X600;
            }
            if (height >= 640 && width >= 480)
            {
                return (int)ImageSize.Size640X480;
            }
            if (height >= 400 && width >= 300)
            {
                return (int)ImageSize.Size400X300;
            }

            return null;
        }
    }
}
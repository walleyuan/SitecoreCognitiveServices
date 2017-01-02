using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Data.Items;

namespace Sitecore.SharedSource.CognitiveServices.Services.Common
{
    public interface IServiceUtil
    {
        MemoryStream GetStream(MediaItem mediaItem);
        Size CalculateDimensions(Size oldSize, int maxSize);
    }
}

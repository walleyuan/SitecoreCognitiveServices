using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Data.Items;

namespace Sitecore.SharedSource.CognitiveServices.Api.Common
{
    public class ApiService : IApiService
    { 
        public virtual MemoryStream GetStream(MediaItem mediaItem)
        {
            Stream mediaStream = mediaItem.GetMediaStream();
            if (mediaStream == null || mediaStream.Length == 0)
                return null;

            using (Image oldImage = Image.FromStream(mediaStream))
            {
                Size newSize = CalculateDimensions(oldImage.Size, 2048);

                using (Bitmap bitmap = new Bitmap(oldImage, newSize))
                {
                    MemoryStream outputStream = new MemoryStream();
                    bitmap.Save(outputStream, ImageFormat.Jpeg);
                    outputStream.Position = 0;

                    return outputStream;
                }
            }
        }

        public virtual Size CalculateDimensions(Size oldSize, int maxSize)
        {
            Size newSize = new Size(oldSize.Width, oldSize.Height);

            if (oldSize.Height > oldSize.Width && oldSize.Height > maxSize)
            {
                newSize.Width = (int)(oldSize.Width * ((float)maxSize / oldSize.Height));
                newSize.Height = maxSize;
            }
            else if (oldSize.Height > oldSize.Width && oldSize.Width > maxSize)
            {
                newSize.Width = maxSize;
                newSize.Height = (int)(oldSize.Height * ((float)maxSize / oldSize.Width));
            }

            return newSize;
        }
    }
}

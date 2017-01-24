﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Data.Items;

namespace Sitecore.SharedSource.CognitiveServices.Services
{
    public class ApiService : IApiService
    { 
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.SharedSource.CognitiveServices.Models;

namespace Sitecore.SharedSource.CognitiveServices.Factories
{
    public class CognitiveImageFactory : ICognitiveImageFactory
    {
        public ICognitiveImage Create()
        {
            ICognitiveImage cImage = new CognitiveImage();
            cImage.Database = string.Empty;
            cImage.Language = string.Empty;
            cImage.ItemId = string.Empty;

            return cImage;
        }
    }
}
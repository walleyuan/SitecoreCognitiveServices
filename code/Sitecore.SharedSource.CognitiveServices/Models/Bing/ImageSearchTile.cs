using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.SharedSource.CognitiveServices.Models.Bing
{
    public class ImageSearchTile
    {
        public ImageSearchQuery Query { get; set; }
        public ImageSearchImage Image { get; set; }
    }
}
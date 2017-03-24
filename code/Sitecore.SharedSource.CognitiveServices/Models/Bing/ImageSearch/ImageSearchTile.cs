using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.SharedSource.CognitiveServices.Models.Bing.ImageSearch {
    public class ImageSearchTile
    {
        public SimpleSearchResult Result { get; set; }
        public ImageSearchImage Image { get; set; }
    }
}
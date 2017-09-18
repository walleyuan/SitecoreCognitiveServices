using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MicrosoftCognitiveServices.Foundation.MSSDK.Models.Bing.ImageSearch {
    public class ImageSearchTile
    {
        public SimpleSearchResult Result { get; set; }
        public ImageSearchImage Image { get; set; }
    }
}
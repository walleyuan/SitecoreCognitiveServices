using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.SharedSource.CognitiveServices.Models.Bing
{
    public class ImageSearchImage
    {
        public string ThumbnailUrl { get; set; }
        public string ContentUrl { get; set; }
        public string ImageSearchThumbnail { get; set; }
        public string ImageId { get; set; }
    }
}
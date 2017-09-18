using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Models.Bing.ImageSearch {
    public class ImageSearchShortResult
    {
        public string Text { get; set; }
        public string DisplayText { get; set; }
        public string WebSearchUrl { get; set; }
        public string SearchLink { get; set; }
        public ImageSearchThumbnailLink Thumbnail { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Microsoft.SharedSource.CognitiveServices.Models.Bing.ImageSearch {
    public class ImageSearchQuickResult
    {
        public string Text { get; set; }
        public string DisplayText { get; set; }
        public string WebSearchUrl { get; set; }
        public ImageSearchThumbnailUrl Thumbnail { get; set; }
    }
}
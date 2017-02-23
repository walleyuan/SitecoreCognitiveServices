using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.SharedSource.CognitiveServices.Models.Bing
{
    public class ImageSearchResult
    {
        public string Name { get; set; }
        public string WebSearchUrl { get; set; }
        public string ThumbnailUrl { get; set; }
        public DateTime DatePublished { get; set; }
        public string ContentUrl { get; set; }
        public string HostPageUrl { get; set; }
        public string ContentSize { get; set; }
        public string EncodingFormat { get; set; }
        public string HostPageDisplayUrl { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public ImageSearchThumbnail Thumbnail { get; set; }
        public string ImageInsightsToken { get; set; }
        public ImageSearchInsightSourceSummary InsightsSourcesSummary { get; set; }
        public string ImageId { get; set; }
        public string AccentColor { get; set; }
    }
}
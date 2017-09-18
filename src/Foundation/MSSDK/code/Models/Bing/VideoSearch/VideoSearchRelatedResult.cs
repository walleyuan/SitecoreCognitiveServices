using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Models.Bing.VideoSearch {
    public class VideoSearchRelatedResult {
        public string Name { get; set; }
        public string WebSearchUrl { get; set; }
        public string ThumbnailUrl { get; set; }
        public DateTime DatePublished { get; set; }
        public List<NameValue> Publisher { get; set; }
        public string ContentUrl { get; set; }
        public string HostPageUrl { get; set; }
        public string hostPageDisplayUrl { get; set; }
        public string Duration { get; set; }
        public string MotionThumbnailUrl { get; set; }
        public bool AllowHttpsEmbed { get; set; }
        public int ViewCount { get; set; }
        public string VideoId { get; set; }
        public bool AllowMobileEmbed { get; set; }
        public bool IsSuperfresh { get; set; }
    }
}
using System;
using System.Collections.Generic;

namespace Sitecore.SharedSource.CognitiveServices.Models.Bing 
{
    public class VideoSearchResult 
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string WebSearchUrl { get; set; }
        public string ThumbnailUrl { get; set; }
        public DateTime DatePublished { get; set; }
        public List<NameValue> Publisher { get; set; }
        public NameValue Creator { get; set; }
        public string ContentUrl { get; set; }
        public string HostPageUrl { get; set; }
        public string HostPageUrlPingSuffix { get; set; }
        public string EncodingFormat { get; set; }
        public string HostPageDisplayUrl { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Duration { get; set; }
        public string MotionThumbnailUrl { get; set; }
        public string EmbedHtml { get; set; }
        public bool AllowHttpsEmbed { get; set; }
        public int ViewCount { get; set; }
        public Thumbnail Thumbnail { get; set; }
        public bool AllowMobileEmbed { get; set; }
        public string VideoId { get; set; }
        public bool IsSuperfresh { get; set; }
    }
}
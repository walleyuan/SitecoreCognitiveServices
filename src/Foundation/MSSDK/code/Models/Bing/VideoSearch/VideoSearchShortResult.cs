
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Bing.ImageSearch;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Models.Bing.VideoSearch {
    public class VideoSearchShortResult {
        public string Text { get; set; }
        public string DisplayText { get; set; }
        public string WebSearchUrl { get; set; }
        public string WebSearchUrlPingSuffix { get; set; }
        public string SearchLink { get; set; }
        public ImageSearchThumbnailLink Thumbnail { get; set; }
    }
}
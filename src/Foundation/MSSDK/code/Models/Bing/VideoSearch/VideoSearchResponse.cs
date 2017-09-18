using System.Collections.Generic;

namespace MicrosoftCognitiveServices.Foundation.MSSDK.Models.Bing.VideoSearch {
    public class VideoSearchResponse {
        public string _type { get; set; }
        public MediaInstrumentation Instrumentation { get; set; }
        public string ReadLink { get; set; }
        public string WebSearchUrl { get; set; }
        public string WebSearchUrlPingSuffix { get; set; }
        public int TotalEstimatedMatches { get; set; }
        public List<VideoSearchResult> Value { get; set; }
        public int NextOffsetAddCount { get; set; }
        public List<VideoSearchShortResult> QueryExpansions { get; set; }
        public List<SearchSuggestion<VideoSearchShortResult>> PivotSuggestions { get; set; }
    }
}
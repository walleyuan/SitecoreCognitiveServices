using System.Collections.Generic;

namespace Sitecore.SharedSource.CognitiveServices.Models.Bing {
    public class VideoSearchDetailsResponse {
        public string _type { get; set; }
        public SearchInstrumentation Instrumentation { get; set; }
        public List<VideoSearchRelatedResult> RelatedVideos { get; set; }
        public List<VideoSearchResult> VideoResult { get; set; }  
    }
}
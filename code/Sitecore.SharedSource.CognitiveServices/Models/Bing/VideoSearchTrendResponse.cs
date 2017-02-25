using System.Collections.Generic;

namespace Sitecore.SharedSource.CognitiveServices.Models.Bing {
    public class VideoSearchTrendResponse {
        public string _type { get; set; }
        public MediaInstrumentation Instrumentation { get; set; }
        public List<VideoSearchTile> BannerTiles { get; set; }
        public List<VideoSearchCategory> Categories { get; set; }  
    }
}
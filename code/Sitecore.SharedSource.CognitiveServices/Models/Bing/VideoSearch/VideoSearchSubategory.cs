using System.Collections.Generic;

namespace Sitecore.SharedSource.CognitiveServices.Models.Bing.VideoSearch {
    public class VideoSearchSubategory {
        public List<VideoSearchTile> Tiles { get; set; }
        public string Title { get; set; }
    }
}
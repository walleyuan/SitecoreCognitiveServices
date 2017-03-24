using System.Collections.Generic;

namespace Sitecore.SharedSource.CognitiveServices.Models.Bing.VideoSearch {
    public class VideoSearchCategory {
        public string Title { get; set; }
        public List<VideoSearchSubategory> Subcategories { get; set; }
    }
}
using System.Collections.Generic;

namespace Microsoft.SharedSource.CognitiveServices.Models.Bing.VideoSearch {
    public class VideoSearchCategory {
        public string Title { get; set; }
        public List<VideoSearchSubategory> Subcategories { get; set; }
    }
}
using System.Collections.Generic;

namespace MicrosoftCognitiveServices.Foundation.MSSDK.Models.Bing.VideoSearch {
    public class VideoSearchCategory {
        public string Title { get; set; }
        public List<VideoSearchSubategory> Subcategories { get; set; }
    }
}
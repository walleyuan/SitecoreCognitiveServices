
namespace Sitecore.SharedSource.CognitiveServices.Models.Bing {
    public class NewsSearchTopicResult {
        public string Name { get; set; }
        public NewsSearchTopicImage Image { get; set; }
        public string WebSearchUrl { get; set; }
        public string WebSearchUrlPingSuffix { get; set; }
        public bool IsBreakingNews { get; set; }
    }
}
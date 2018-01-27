
namespace SitecoreCognitiveServices.Feature.ImageSearch.Areas.SitecoreCognitiveServices.Models.Utility
{
    public class AnalyzeAll : IAnalyzeAll
    {
        public string ItemId { get; set; }
        public string Database { get; set; }
        public string Language { get; set; }
        public string HandleName { get; set; }
    }
}
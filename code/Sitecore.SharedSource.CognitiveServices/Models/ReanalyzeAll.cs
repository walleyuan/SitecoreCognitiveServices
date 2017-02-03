
namespace Sitecore.SharedSource.CognitiveServices.Models
{
    public class ReanalyzeAll : IReanalyzeAll
    {
        public string ItemId { get; set; }
        public string Database { get; set; }
        public string Language { get; set; }
        public int ItemCount { get; set; }
    }
}
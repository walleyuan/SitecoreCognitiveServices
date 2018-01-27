
namespace SitecoreCognitiveServices.Feature.ImageSearch.Areas.SitecoreCognitiveServices.Models
{
    public class CognitiveImageSearchJsonResult : ICognitiveImageSearchJsonResult
    {
        public string Url { get; set; }
        public string Alt { get; set; }
        public string Id { get; set; }
    }
}
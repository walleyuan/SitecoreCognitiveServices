
namespace SitecoreCognitiveServices.Feature.ImageSearch.Models
{
    public class CognitiveImageSearchJsonResult : ICognitiveImageSearchJsonResult
    {
        public string Url { get; set; }
        public string Alt { get; set; }
        public string Id { get; set; }
    }
}
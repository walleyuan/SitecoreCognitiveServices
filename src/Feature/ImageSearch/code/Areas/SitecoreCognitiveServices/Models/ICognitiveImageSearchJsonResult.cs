namespace SitecoreCognitiveServices.Feature.ImageSearch.Areas.SitecoreCognitiveServices.Models
{
    public interface ICognitiveImageSearchJsonResult
    {
        string Url { get; set; }
        string Alt { get; set; }
        string Id { get; set; }
    }
}
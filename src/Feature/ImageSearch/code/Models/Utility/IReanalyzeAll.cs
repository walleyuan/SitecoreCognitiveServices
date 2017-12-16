
namespace SitecoreCognitiveServices.Feature.ImageSearch.Models.Utility
{
    public interface IReanalyzeAll
    {
        string ItemId { get; set; }
        string Database { get; set; }
        string Language { get; set; }
        int ItemCount { get; set; }
    }
}
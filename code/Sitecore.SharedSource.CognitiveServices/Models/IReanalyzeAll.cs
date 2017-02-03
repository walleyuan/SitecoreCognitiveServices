
namespace Sitecore.SharedSource.CognitiveServices.Models
{
    public interface IReanalyzeAll
    {
        int ItemCount { get; set; }
        string Database { get; set; }
        string Language { get; set; }
        string ItemId { get; set; }
    }
}
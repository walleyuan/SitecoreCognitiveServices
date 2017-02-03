
namespace Sitecore.SharedSource.CognitiveServices.Models
{
    public interface ISetAltTagsAll
    {
        int ItemCount { get; set; }
        int ItemsModified { get; set; }
        string Database { get; set; }
        string Language { get; set; }
        string ItemId { get; set; }
    }
}
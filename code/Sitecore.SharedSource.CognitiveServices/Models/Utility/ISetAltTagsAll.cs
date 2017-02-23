
namespace Sitecore.SharedSource.CognitiveServices.Models.Utility
{
    public interface ISetAltTagsAll
    {
        string ItemId { get; set; }
        string Database { get; set; }
        string Language { get; set; }
        int ItemCount { get; set; }
        int ItemsModified { get; set; }
        int Threshold { get; set; }
        bool Overwrite { get; set; }
    }
}
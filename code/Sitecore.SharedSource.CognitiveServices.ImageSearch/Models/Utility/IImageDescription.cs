using Microsoft.ProjectOxford.Vision.Contract;

namespace Sitecore.SharedSource.CognitiveServices.ImageSearch.Models.Utility
{
    public interface IImageDescription
    {
        Description CognitiveDescription { get; set; }
        string AltDescription { get; set; }
        string ItemId { get; set; }
        string Database { get; set; }
        string Language { get; set; }
    }
}
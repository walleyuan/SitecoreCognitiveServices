
using MicrosoftCognitiveServices.Foundation.MSSDK.Models.Vision.Computer;

namespace SitecoreCognitiveServices.Feature.ImageSearch.Models.Utility
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
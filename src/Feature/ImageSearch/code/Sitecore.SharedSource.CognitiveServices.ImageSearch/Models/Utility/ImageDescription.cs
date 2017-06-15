using Microsoft.ProjectOxford.Vision.Contract;

namespace Sitecore.SharedSource.CognitiveServices.ImageSearch.Models.Utility
{
    public class ImageDescription : IImageDescription
    {
        public Description CognitiveDescription { get; set; }
        public string AltDescription { get; set; }
        public string ItemId { get; set; }
        public string Database { get; set; }
        public string Language { get; set; }
    }
}
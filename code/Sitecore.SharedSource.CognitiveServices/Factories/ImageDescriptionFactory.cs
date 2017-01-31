using Microsoft.ProjectOxford.Vision.Contract;
using Sitecore.SharedSource.CognitiveServices.Models;
using Sitecore.SharedSource.CognitiveServices.Search;

namespace Sitecore.SharedSource.CognitiveServices.Factories
{
    public class ImageDescriptionFactory : IImageDescriptionFactory
    {
        public IImageDescription Create()
        {
            return new ImageDescription()
            {
                CognitiveDescription = new Description(),
                AltDescription = string.Empty,
                ItemId = string.Empty,
                Database = string.Empty,
                Language = string.Empty
            };
        }

        public IImageDescription Create(Description cognitiveDescription, string altDescription, string itemId, string database, string language)
        {
            return new ImageDescription()
            {
                CognitiveDescription = cognitiveDescription,
                AltDescription = altDescription,
                ItemId = itemId,
                Database = database,
                Language = language
            };
        }
    }
}
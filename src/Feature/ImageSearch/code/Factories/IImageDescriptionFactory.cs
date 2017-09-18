using MicrosoftCognitiveServices.Foundation.MSSDK.Models.Vision.Computer;
using SitecoreCognitiveServices.Feature.ImageSearch.Models;
using SitecoreCognitiveServices.Feature.ImageSearch.Models.Utility;
using SitecoreCognitiveServices.Feature.ImageSearch.Search;

namespace SitecoreCognitiveServices.Feature.ImageSearch.Factories
{
    public interface IImageDescriptionFactory
    {
        IImageDescription Create();
        IImageDescription Create(Description cognitiveDescription, string altDescription, string itemId, string database, string language);
    }
}
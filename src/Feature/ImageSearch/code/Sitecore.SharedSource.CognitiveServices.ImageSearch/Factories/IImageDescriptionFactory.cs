using Microsoft.ProjectOxford.Vision.Contract;
using Sitecore.SharedSource.CognitiveServices.ImageSearch.Models;
using Sitecore.SharedSource.CognitiveServices.ImageSearch.Models.Utility;
using Sitecore.SharedSource.CognitiveServices.ImageSearch.Search;

namespace Sitecore.SharedSource.CognitiveServices.ImageSearch.Factories
{
    public interface IImageDescriptionFactory
    {
        IImageDescription Create();
        IImageDescription Create(Description cognitiveDescription, string altDescription, string itemId, string database, string language);
    }
}
using Microsoft.ProjectOxford.Vision.Contract;
using Sitecore.SharedSource.CognitiveServices.Models;
using Sitecore.SharedSource.CognitiveServices.Search;

namespace Sitecore.SharedSource.CognitiveServices.Factories
{
    public interface IImageDescriptionFactory
    {
        IImageDescription Create();
        IImageDescription Create(Description cognitiveDescription, string altDescription, string itemId, string database, string language);
    }
}
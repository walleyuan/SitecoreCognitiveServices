using Microsoft.ProjectOxford.Vision.Contract;
using Sitecore.SharedSource.CognitiveServices.Models;
using Sitecore.SharedSource.CognitiveServices.Search;

namespace Sitecore.SharedSource.CognitiveServices.Factories
{
    public interface IProcessResultFactory
    {
        IProcessResult Create();

        IProcessResult Create(int itemCount, string itemId, string database, string language);
    }
}
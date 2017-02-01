using Microsoft.ProjectOxford.Vision.Contract;
using Sitecore.SharedSource.CognitiveServices.Models;
using Sitecore.SharedSource.CognitiveServices.Search;

namespace Sitecore.SharedSource.CognitiveServices.Factories
{
    public class ProcessResultFactory : IProcessResultFactory
    {
        public IProcessResult Create()
        {
            return new ProcessResult()
            {
                ItemCount = 0,
                ItemId = string.Empty,
                Database = string.Empty,
                Language = string.Empty
            };
        }

        public IProcessResult Create(int itemCount, string itemId, string database, string language)
        {
            return new ProcessResult()
            {
                ItemCount = itemCount,
                ItemId = itemId,
                Database = database,
                Language = language
            };
        }
    }
}
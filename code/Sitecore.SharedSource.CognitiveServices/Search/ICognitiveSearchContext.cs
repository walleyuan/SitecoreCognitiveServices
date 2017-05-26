using System.Collections.Generic;
using Sitecore.Data.Items;

namespace Sitecore.SharedSource.CognitiveServices.Search
{
    public interface ICognitiveSearchContext
    {
        ICognitiveSearchResult GetAnalysis(string itemId, string languageCode, string dbName);
        
        void AddItemToIndex(string itemId, string dbName);

        void AddItemToIndex(Item item, string dbName);

        void UpdateItemInIndex(string itemId, string dbName);

        void UpdateItemInIndex(Item item, string dbName);
    }
}
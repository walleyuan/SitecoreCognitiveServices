using System.Collections.Generic;
using Sitecore.Data.Items;

namespace Sitecore.SharedSource.CognitiveServices.Search
{
    public interface ICognitiveSearchContext
    {
        ICognitiveSearchResult GetAnalysis(string itemId, string languageCode, string dbName);

        List<ICognitiveSearchResult> GetMediaResults(string query, string languageCode, string dbName);

        List<ICognitiveSearchResult> GetMediaResults(Dictionary<string, string[]> tagParameters, Dictionary<string, string[]> rangeParameters, int gender, int glasses, string languageCode, string dbName);

        string[] GetAutocompleteResults(string term, string languageCode, string dbName);

        List<KeyValuePair<string, int>> GetTags(string languageCode, string dbName);

        void AddItemToIndex(string itemId, string dbName);

        void AddItemToIndex(Item item, string dbName);

        void UpdateItemInIndex(string itemId, string dbName);

        void UpdateItemInIndex(Item item, string dbName);
    }
}
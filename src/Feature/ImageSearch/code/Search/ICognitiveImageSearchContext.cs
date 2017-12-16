using System.Collections.Generic;
using System.Linq.Expressions;
using System;
using Sitecore.Data.Items;

namespace SitecoreCognitiveServices.Feature.ImageSearch.Search
{
    public interface ICognitiveImageSearchContext
    {
        ICognitiveImageSearchResult GetAnalysis(string itemId, string languageCode, string dbName);
        void AddItemToIndex(string itemId, string dbName);
        void AddItemToIndex(Item item, string dbName);
        void UpdateItemInIndex(string itemId, string dbName);
        void UpdateItemInIndex(Item item, string dbName);
        List<ICognitiveImageSearchResult> GetMediaResults(Dictionary<string, string[]> tagParameters, Dictionary<string, string[]> rangeParameters, int gender, int glasses, int size, string languageCode, string dbName);
        Expression<Func<CognitiveImageSearchResult, bool>> GetDefaultFilter(string[] parameterValues, string fieldName);
        Expression<Func<CognitiveImageSearchResult, bool>> GetRangeFilter(string[] parameterValues, string fieldName);
        List<KeyValuePair<string, int>> GetTags(string languageCode, string dbName);
    }
}
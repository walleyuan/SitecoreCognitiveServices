using System.Collections.Generic;
using Sitecore.SharedSource.CognitiveServices.Search;
using System.Linq.Expressions;
using System;

namespace Sitecore.SharedSource.CognitiveServices.ImageSearch.Search
{
    public interface ICognitiveImageSearchContext : ICognitiveSearchContext
    {
        List<ICognitiveImageSearchResult> GetMediaResults(string query, string languageCode, string dbName);
        List<ICognitiveImageSearchResult> GetMediaResults(Dictionary<string, string[]> tagParameters, Dictionary<string, string[]> rangeParameters, int gender, int glasses, int size, string languageCode, string dbName);
        Expression<Func<CognitiveImageSearchResult, bool>> GetDefaultFilter(string[] parameterValues, string fieldName);
        Expression<Func<CognitiveImageSearchResult, bool>> GetRangeFilter(string[] parameterValues, string fieldName);
        List<KeyValuePair<string, int>> GetTags(string languageCode, string dbName);
    }
}
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Vision.Computer;
using Sitecore.Data.Items;
using SitecoreCognitiveServices.Feature.ImageSearch.Models.Analysis;
using SitecoreCognitiveServices.Feature.ImageSearch.Models.Utility;

namespace SitecoreCognitiveServices.Feature.ImageSearch.Search {
    public interface IImageSearchService
    {
        void AddItemToIndex(string itemId, string dbName);
        void AddItemToIndex(Item item, string dbName);
        void UpdateItemInIndex(string itemId, string dbName);
        void UpdateItemInIndex(Item item, string dbName);
        int UpdateItemInIndexRecursively(Item item, string db);
        List<ICognitiveImageSearchResult> GetMediaResults(Dictionary<string, string[]> tagParameters, Dictionary<string, string[]> rangeParameters, int gender, int glasses, int size, string languageCode, string dbName);
        ICognitiveImageSearchResult GetAnalysis(string itemId, string languageCode, string dbName);
        ICognitiveImageSearchResult GetCognitiveSearchResult(string itemId, string language, string db);
        ICognitiveImageAnalysis GetImageAnalysis(string id, string language, string db);
        IImageDescription GetImageDescription(MediaItem m, string language);
        Caption GetTopImageCaption(MediaItem m, string language, double threshold);
        List<KeyValuePair<string, int>> GetTags(string languageCode, string dbName);
        Expression<Func<CognitiveImageSearchResult, bool>> GetDefaultFilter(string[] parameterValues, string fieldName);
        Expression<Func<CognitiveImageSearchResult, bool>> GetRangeFilter(string[] parameterValues, string fieldName);
    }
}
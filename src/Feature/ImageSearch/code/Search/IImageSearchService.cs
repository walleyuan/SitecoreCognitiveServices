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
        /// <summary>
        /// Converts a cognitive search result into an image analysis
        /// </summary>
        ICognitiveImageAnalysis GetImageAnalysis(string id, string language, string db);
        /// <summary>
        /// Finds the analysis item in the content tree.
        /// </summary>
        /// <param name="itemName">Should be the short id of a media item</param>
        Item GetImageAnalysisItem(string itemName, string languageCode, string dbName);
        /// <summary>
        /// Cognitive image search result has custom index fields that store the analysis in computed fields
        /// </summary>
        ICognitiveImageSearchResult GetCognitiveSearchResult(string itemId, string language, string db);
        List<ICognitiveImageSearchResult> GetMediaResults(Dictionary<string, string[]> tagParameters, Dictionary<string, string[]> rangeParameters, int gender, int glasses, int size, string languageCode, string dbName);
        IImageDescription GetImageDescription(MediaItem m, string language);
        Caption GetTopImageCaption(MediaItem m, string language, double threshold);
        List<KeyValuePair<string, int>> GetTags(string languageCode, string dbName);
        Expression<Func<CognitiveImageSearchResult, bool>> GetDefaultFilter(string[] parameterValues, string fieldName);
        Expression<Func<CognitiveImageSearchResult, bool>> GetRangeFilter(string[] parameterValues, string fieldName);
        string GetSitecoreIndexName(string dbName);
        string GetCognitiveIndexName(string dbName);
    }
}
using Microsoft.ProjectOxford.Vision.Contract;
using Sitecore.Data.Items;
using Sitecore.SharedSource.CognitiveServices.ImageSearch.Models.Analysis;
using Sitecore.SharedSource.CognitiveServices.ImageSearch.Models.Utility;
using Sitecore.SharedSource.CognitiveServices.ImageSearch.Search;

namespace Sitecore.SharedSource.CognitiveServices.ImageSearch.Services.Search {
    public interface IImageSearchService
    {
        void UpdateItemInIndex(string itemId, string db);
        void UpdateItemInIndex(Item item, string db);
        int UpdateItemInIndexRecursively(Item item, string db);
        ICognitiveImageSearchResult GetCognitiveSearchResult(string itemId, string language, string db);
        ICognitiveImageAnalysis GetImageAnalysis(string id, string language, string db);
        IImageDescription GetImageDescription(MediaItem m, string language);
        Caption GetTopImageCaption(MediaItem m, string language, double threshold);
    }
}
using MicrosoftCognitiveServices.Foundation.MSSDK.Models.Vision.Computer;
using Sitecore.Data.Items;
using SitecoreCognitiveServices.Feature.ImageSearch.Models.Analysis;
using SitecoreCognitiveServices.Feature.ImageSearch.Models.Utility;
using SitecoreCognitiveServices.Feature.ImageSearch.Search;

namespace SitecoreCognitiveServices.Feature.ImageSearch.Services.Search {
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
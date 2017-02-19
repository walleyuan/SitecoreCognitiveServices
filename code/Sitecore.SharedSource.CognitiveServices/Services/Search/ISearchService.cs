using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.ProjectOxford.Vision.Contract;
using Sitecore.Data.Items;
using Sitecore.SharedSource.CognitiveServices.Models;
using Sitecore.SharedSource.CognitiveServices.Search;

namespace Sitecore.SharedSource.CognitiveServices.Services.Search {
    public interface ISearchService
    {
        void UpdateItemInIndex(string itemId, string db);
        void UpdateItemInIndex(Item item, string db);
        int UpdateItemInIndexRecursively(Item item, string db);
        ICognitiveSearchResult GetCognitiveSearchResult(string itemId, string language, string db);
        ICognitiveImageAnalysis GetImageAnalysis(string id, string language, string db);
        ICognitiveTextAnalysis GetTextAnalysis(string id, string language, string db);
        IImageDescription GetImageDescription(MediaItem m, string language);
        Caption GetTopImageCaption(MediaItem m, string language, double threshold);
    }
}
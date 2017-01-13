using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data.Items;

namespace Sitecore.SharedSource.CognitiveServices.Search
{
    public interface ICognitiveSearchContext
    {
        ICognitiveSearchResult GetAnalysis(string itemId, string languageCode);

        void AddItemToIndex(string itemId);

        void AddItemToIndex(Item item);

        void UpdateItemInIndex(string itemId);

        void UpdateItemInIndex(Item item);
    }
}
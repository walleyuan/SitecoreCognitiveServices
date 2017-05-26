using System.Collections.Generic;
using Sitecore.ContentSearch;
using Sitecore.SharedSource.CognitiveServices.Search;

namespace Sitecore.SharedSource.CognitiveServices.ImageSearch.Search
{
    public class CognitiveImageSearchResult : CognitiveSearchResult, ICognitiveImageSearchResult
    {
        #region properties
        
        [IndexField("gender")]
        public int Gender { get; set; }

        [IndexField("size")]
        public int Size { get; set; }

        [IndexField("glasses")]
        public List<int> Glasses { get; set; }

        [IndexField("Tags")]
        public string[] Tags { get; set; }

        [IndexField("AgeMin")]
        public double AgeMin { get; set; }

        [IndexField("AgeMax")]
        public double AgeMax { get; set; }

        #endregion properties
    }
}
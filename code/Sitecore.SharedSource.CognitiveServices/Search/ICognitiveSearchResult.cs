using Sitecore.ContentSearch;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.SharedSource.CognitiveServices.Search
{
    public interface ICognitiveSearchResult : ISearchResult
    {
        string EmotionAnalysis { get; set; }
        string FacialAnalysis { get; set; }
        string TextAnalysis { get; set; }
        string VisionAnalysis { get; set; }
        string LanguageAnalysis { get; set; }
        string LinkAnalysis { get; set; }
        string SentimentAnalysis { get; set; }
        string UniqueId { get; set; }
    }
}
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
        string ImageItemAnalysis { get; set; }
        string TextFieldAnalysis { get; set; }
        string UniqueID { get; set; }
    }
}
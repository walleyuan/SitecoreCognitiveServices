using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using Microsoft.SharedSource.CognitiveServices.Models.Vision.Computer;
using Microsoft.SharedSource.CognitiveServices.Models.Vision.Emotion;
using Microsoft.SharedSource.CognitiveServices.Models.Vision.Face;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;

namespace Sitecore.SharedSource.CognitiveServices.OleChat.Search
{
    public class SearchResult : SearchResultItem, ISearchResult
    {
    }
}
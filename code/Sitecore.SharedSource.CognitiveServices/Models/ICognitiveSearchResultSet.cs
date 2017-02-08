using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.SharedSource.CognitiveServices.Search;

namespace Sitecore.SharedSource.CognitiveServices.Models
{
    public interface ICognitiveSearchResultSet
    {
        List<ICognitiveSearchResult> Results { get; set; }
    }
}
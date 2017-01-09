using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.SharedSource.CognitiveServices.Search
{
    public interface ICognitiveSearchContext
    {
        ICognitiveSearchResult GetAnalysis(string itemId, string languageCode);
    }
}
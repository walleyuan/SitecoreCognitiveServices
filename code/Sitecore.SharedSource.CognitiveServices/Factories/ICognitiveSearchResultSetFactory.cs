using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.SharedSource.CognitiveServices.Models;
using Sitecore.SharedSource.CognitiveServices.Search;
using Sitecore.Shell.Framework.Commands;

namespace Sitecore.SharedSource.CognitiveServices.Factories
{
    public interface ICognitiveSearchResultSetFactory
    {
        ICognitiveSearchResultSet Create();
        ICognitiveSearchResultSet Create(List<ICognitiveSearchResult> results);
    }
}
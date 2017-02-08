using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.SharedSource.CognitiveServices.Models;
using Sitecore.SharedSource.CognitiveServices.Search;
using Sitecore.Shell.Framework.Commands;

namespace Sitecore.SharedSource.CognitiveServices.Factories
{
    public class CognitiveSearchResultSetFactory : ICognitiveSearchResultSetFactory
    {
        public ICognitiveSearchResultSet Create()
        {
            return new CognitiveSearchResultSet();
        }

        public ICognitiveSearchResultSet Create(List<ICognitiveSearchResult> results)
        {
            var r = Create();
            r.Results = results;

            return r;
        }
    }
}
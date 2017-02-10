using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.SharedSource.CognitiveServices.Models;
using Sitecore.SharedSource.CognitiveServices.Search;
using Sitecore.Shell.Framework.Commands;

namespace Sitecore.SharedSource.CognitiveServices.Factories
{
    public class CognitiveMediaSearchFactory : ICognitiveMediaSearchFactory
    {
        public ICognitiveMediaSearch Create()
        {
            return new CognitiveMediaSearch();
        }

        public ICognitiveMediaSearch Create(string db, string language)
        {
            var r = Create();
            r.Database = db;
            r.Language = language;

            return r;
        }
    }
}
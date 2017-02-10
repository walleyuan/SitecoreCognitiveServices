using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.SharedSource.CognitiveServices.Models;
using Sitecore.SharedSource.CognitiveServices.Search;
using Sitecore.Shell.Framework.Commands;

namespace Sitecore.SharedSource.CognitiveServices.Factories
{
    public interface ICognitiveMediaSearchFactory
    {
        ICognitiveMediaSearch Create();
        ICognitiveMediaSearch Create(string db, string language);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.SharedSource.CognitiveServices.Models;
using Sitecore.SharedSource.CognitiveServices.Search;

namespace Sitecore.SharedSource.CognitiveServices.Factories
{
    public interface ICognitiveImageAnalysisFactory
    {
        ICognitiveImageAnalysis Create();
        ICognitiveImageAnalysis Create(ICognitiveSearchResult result);
    }
}
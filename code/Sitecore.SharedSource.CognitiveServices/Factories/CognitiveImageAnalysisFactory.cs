using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.SharedSource.CognitiveServices.Models;
using System.Web.Script.Serialization;
using Sitecore.SharedSource.CognitiveServices.Search;

namespace Sitecore.SharedSource.CognitiveServices.Factories
{
    public class CognitiveImageAnalysisFactory : ICognitiveImageAnalysisFactory
    {
        public ICognitiveImageAnalysis Create()
        {
            return new CognitiveImageAnalysis();
        }

        public ICognitiveImageAnalysis Create(ICognitiveSearchResult result) {

            var json = (result != null) ? result.ImageItemAnalysis : string.Empty;

            var obj = new JavaScriptSerializer().Deserialize<CognitiveImageAnalysis>(json);
            return obj ?? Create();
        }
    }
}
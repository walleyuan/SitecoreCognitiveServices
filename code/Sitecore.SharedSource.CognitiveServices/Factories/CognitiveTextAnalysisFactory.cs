using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.SharedSource.CognitiveServices.Models;
using System.Web.Script.Serialization;
using Sitecore.SharedSource.CognitiveServices.Search;

namespace Sitecore.SharedSource.CognitiveServices.Factories
{
    public class CognitiveTextAnalysisFactory : ICognitiveTextAnalysisFactory
    {
        public ICognitiveTextAnalysis Create()
        {
            return new CognitiveTextAnalysis();
        }

        public ICognitiveTextAnalysis Create(ICognitiveSearchResult result)
        {
            var json = (result != null) ? result.TextFieldAnalysis : string.Empty;

            var obj = new JavaScriptSerializer().Deserialize<CognitiveTextAnalysis>(json);
            return obj ?? Create();
        }
    }
}
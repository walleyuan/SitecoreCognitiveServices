using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.SharedSource.CognitiveServices.Models;
using System.Web.Script.Serialization;

namespace Sitecore.SharedSource.CognitiveServices.Factories
{
    public class CognitiveTextAnalysisFactory : ICognitiveTextAnalysisFactory
    {
        public ICognitiveTextAnalysis Create()
        {
            return new CognitiveTextAnalysis();
        }

        public ICognitiveTextAnalysis Create(string json)
        {
            var obj = new JavaScriptSerializer().Deserialize<CognitiveTextAnalysis>(json);
            return (obj != null)
                ? obj
                : Create();
        }
    }
}
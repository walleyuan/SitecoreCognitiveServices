using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.SharedSource.CognitiveServices.Models;
using System.Web.Script.Serialization;

namespace Sitecore.SharedSource.CognitiveServices.Factories
{
    public class CognitiveImageAnalysisFactory : ICognitiveImageAnalysisFactory
    {
        public ICognitiveImageAnalysis Create()
        {
            return new CognitiveImageAnalysis();
        }

        public ICognitiveImageAnalysis Create(string json) {
            var obj = new JavaScriptSerializer().Deserialize<CognitiveImageAnalysis>(json);
            return (obj != null)
                ? obj
                : Create();
        }
    }
}
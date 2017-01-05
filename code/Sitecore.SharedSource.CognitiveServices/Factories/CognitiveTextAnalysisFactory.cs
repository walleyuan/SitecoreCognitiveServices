using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.SharedSource.CognitiveServices.Models;

namespace Sitecore.SharedSource.CognitiveServices.Factories
{
    public class CognitiveTextAnalysisFactory : ICognitiveTextAnalysisFactory
    {
        public ICognitiveTextAnalysis Create()
        {
            return new CognitiveTextAnalysis();
        }
    }
}
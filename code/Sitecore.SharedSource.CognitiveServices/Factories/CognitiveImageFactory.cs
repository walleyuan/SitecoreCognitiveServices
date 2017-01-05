using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.SharedSource.CognitiveServices.Models;

namespace Sitecore.SharedSource.CognitiveServices.Factories
{
    public class CognitiveImageFactory : ICognitiveImageFactory
    {
        public ICognitiveImageAnalysisFactory AnalysisFactory;

        public CognitiveImageFactory(ICognitiveImageAnalysisFactory analysisFactory)
        {
            AnalysisFactory = analysisFactory;
        }

        public ICognitiveImage Create(string database = "", string language = "", string itemId = "")
        {
            var ci = new CognitiveImage(database, language, itemId);
            ci.Analysis = AnalysisFactory.Create();

            return ci;
        }
    }
}
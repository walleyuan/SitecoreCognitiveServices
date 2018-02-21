using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SitecoreCognitiveServices.Feature.ImageSearch.Areas.SitecoreCognitiveServices.Models.Analysis;

namespace SitecoreCognitiveServices.Feature.ImageSearch.Setup
{
    public interface ISetupService
    {
        ICognitiveImageAnalysis SaveKeysAndAnalyze(string faceApi, string faceApiEndpoint, string computerVisionApi, string computerVisionApiEndpoint);
        string SetFieldsFolderTemplate();
        void ConfigureIndexes(string indexOption);
    }
}
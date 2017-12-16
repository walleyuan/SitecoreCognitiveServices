using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SitecoreCognitiveServices.Foundation.IBMSDK.Models.NaturalLanguageClassifier;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.IBMSDK
{
    public interface INaturalLanguageClassifierService
    {
        ClassifyResponse Classify(string classifier_id, string text);
        CreateClassifierResponse CreateClassifier(string classifier_id, string training_data_language, string training_data);
        void DeleteClassifier(string classifier_id);
        GetClassifierInfoResponse GetClassifierInfo(string classifier_id);
        ListClassifierResponse ListClassifiers();
    }
}
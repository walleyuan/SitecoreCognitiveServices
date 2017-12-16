using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SitecoreCognitiveServices.Foundation.IBMSDK.Models.NaturalLanguageClassifier;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.Repositories
{
    public interface INaturalLanguageClassifierRepository
    {
        CreateClassifierResponse CreateClassifier(string classifier_name, string training_data_language, string training_data);
        ListClassifierResponse ListClassifiers();
        GetClassifierInfoResponse GetClassifierInfo(string classifier_id);
        void DeleteClassifier(string classifier_id);
        ClassifyResponse Classify(string classifier_id, string text);
    }
}
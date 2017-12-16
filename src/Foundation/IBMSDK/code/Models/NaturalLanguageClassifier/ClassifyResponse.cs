using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SitecoreCognitiveServices.Foundation.IBMSDK.Models.NaturalLanguageClassifier;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.Models.NaturalLanguageClassifier
{
    public class ClassifyResponse
    {
        public string classifier_id { get; set; }
        public string url { get; set; }
        public string text { get; set; }
        public string top_class { get; set; }
        public Classification[] classes { get; set; }
    }
}
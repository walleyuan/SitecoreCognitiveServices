using System;
using System.Collections.Generic;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.Models.NaturalLanguageClassifier
{
    public class Classifier
    {
        public string classifier_id { get; set; }
        public string url { get; set; }
        public string name { get; set; }
        public string language { get; set; }
        public DateTime created { get; set; }
    }
}
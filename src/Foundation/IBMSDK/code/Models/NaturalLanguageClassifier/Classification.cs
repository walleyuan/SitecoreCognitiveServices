using System;
using System.Collections.Generic;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.Models.NaturalLanguageClassifier
{
    public class Classification
    {
        public string class_name { get; set; }
        public float confidence { get; set; }
    }
}
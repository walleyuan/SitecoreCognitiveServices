using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Microsoft.SharedSource.CognitiveServices.Models.Bing.WebSearch {
    public class WebSearchMainlineItem
    {
        public string AnswerType { get; set; }
        public int ResultIndex { get; set; }
        public IdValue Id { get; set; }
    }
}
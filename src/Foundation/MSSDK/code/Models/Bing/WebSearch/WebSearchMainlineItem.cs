using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Models.Bing.WebSearch {
    public class WebSearchMainlineItem
    {
        public string AnswerType { get; set; }
        public int ResultIndex { get; set; }
        public IdValue Id { get; set; }
    }
}
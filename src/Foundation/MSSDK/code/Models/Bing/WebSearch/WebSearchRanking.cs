using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MicrosoftCognitiveServices.Foundation.MSSDK.Models.Bing.WebSearch {
    public class WebSearchRanking
    {
        public WebSearchMainline Mainline { get; set; }
        public WebSearchSidebar Sidebar { get; set; }
    }
}
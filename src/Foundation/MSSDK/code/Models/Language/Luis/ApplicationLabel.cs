using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Models.Language.Luis {
    public class ApplicationLabel {
        public string EntityName { get; set; }
        public int StartCharIndex { get; set; }
        public int EndCharIndex { get; set; }
    }
}
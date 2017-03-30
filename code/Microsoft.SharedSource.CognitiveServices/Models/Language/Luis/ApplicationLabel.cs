using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Microsoft.SharedSource.CognitiveServices.Models.Language.Luis {
    public class ApplicationLabel {
        public string EntityName { get; set; }
        public int StartCharIndex { get; set; }
        public int EndCharIndex { get; set; }
    }
}
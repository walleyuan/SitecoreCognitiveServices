using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Microsoft.SharedSource.CognitiveServices.Models.Language.Luis {
    public class EntityPrediction {
        public string EntityName { get; set; }
        public int StartIndex { get; set; }
        public int EndIndex { get; set; }
        public string Phrase { get; set; }
    }
}
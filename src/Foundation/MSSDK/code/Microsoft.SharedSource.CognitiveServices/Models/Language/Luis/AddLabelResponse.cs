using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Microsoft.SharedSource.CognitiveServices.Models.Language.Luis {
    public class AddLabelResponse {
        public string UtteranceText { get; set; }
        public int ExampleId { get; set; }
    }
}
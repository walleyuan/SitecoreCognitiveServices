using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Microsoft.SharedSource.CognitiveServices.Models.Language.Luis {
    public class AddLabelRequest {
        public string Text { get; set; }
        public string IntentName { get; set; }
        public ApplicationLabel[] EntityLabels { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.SharedSource.CognitiveServices.Models.Language.Luis {
    public class BatchAddLabelsResponse {
        public AddLabelResponse Value { get; set; }
        public bool HasError { get; set; }
    }
}
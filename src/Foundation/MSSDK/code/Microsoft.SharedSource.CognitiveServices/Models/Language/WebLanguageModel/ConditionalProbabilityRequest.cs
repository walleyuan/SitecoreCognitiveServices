using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Microsoft.SharedSource.CognitiveServices.Models.Language.WebLanguageModel {
    public class ConditionalProbabilityRequest
    {
        public List<ConditionalProbabilityQuery> Queries { get; set; }
    }
}
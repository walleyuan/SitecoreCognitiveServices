using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.SharedSource.CognitiveServices.Models.Language.Linguistic;

namespace Microsoft.SharedSource.CognitiveServices.Models.Language.WebLanguageModel {
    public class GenerateNextWordsResponse
    {
        public List<NextWordCandidate> Candidates { get; set; }
    }
}
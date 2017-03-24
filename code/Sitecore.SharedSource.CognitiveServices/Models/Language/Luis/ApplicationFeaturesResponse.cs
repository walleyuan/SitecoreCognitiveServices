using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.SharedSource.CognitiveServices.Models.Language.Luis {
    public class ApplicationFeaturesResponse {
        public PhraseListFeature[] PhraselistFeatures { get; set; }
        public PatternFeature[] PatternFeatures { get; set; }
    }
}
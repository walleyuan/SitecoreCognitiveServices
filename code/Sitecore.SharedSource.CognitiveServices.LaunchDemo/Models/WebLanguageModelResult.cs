using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.SharedSource.CognitiveServices.Models.Language;
using Microsoft.SharedSource.CognitiveServices.Models.Language.WebLanguageModel;

namespace Sitecore.SharedSource.CognitiveServices.LaunchDemo.Models
{
    public class WebLanguageModelResult
    {
        public BreakIntoWordsResponse BreakIntoWords { get; set; }
        public ConditionalProbabilityResponse ConditionalProbability { get; set; }
        public JointProbabilityResponse JointProbability { get; set; }
        public GenerateNextWordsResponse NextWords { get; set; }
        public WebLMModelResponse WebLMModels { get; set; }
    }
}
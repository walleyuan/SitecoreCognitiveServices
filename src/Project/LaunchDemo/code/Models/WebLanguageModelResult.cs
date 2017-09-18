using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Language;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Language.WebLanguageModel;

namespace SitecoreCognitiveServices.Project.LaunchDemo.Models
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
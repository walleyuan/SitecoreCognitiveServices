using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.SharedSource.CognitiveServices.Models.Language.WebLanguageModel
{
    public class BreakIntoWordsCandidate
    {
        public string Words { get; set; }
        public double Probability { get; set; }
    }
}
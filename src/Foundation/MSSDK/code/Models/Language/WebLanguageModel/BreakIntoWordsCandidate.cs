using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Models.Language.WebLanguageModel
{
    public class BreakIntoWordsCandidate
    {
        public string Words { get; set; }
        public double Probability { get; set; }
    }
}
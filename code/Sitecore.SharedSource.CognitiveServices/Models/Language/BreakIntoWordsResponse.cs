using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.SharedSource.CognitiveServices.Models.Language
{
    public class BreakIntoWordsResponse
    {
        public List<BreakIntoWordsCandidate> Candidates { get; set; }
    }
}
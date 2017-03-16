using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.SharedSource.CognitiveServices.Models.Language
{
    public class GenerateNextWordsResponse
    {
        public List<NextWordCandidate> Candidates { get; set; }
    }
}
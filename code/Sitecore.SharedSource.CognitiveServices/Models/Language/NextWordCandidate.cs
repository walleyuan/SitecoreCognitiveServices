using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.SharedSource.CognitiveServices.Models.Language
{
    public class NextWordCandidate
    {
        public string Word { get; set; }
        public double Probability { get; set; }
    }
}
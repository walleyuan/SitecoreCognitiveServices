using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.SharedSource.CognitiveServices.Models.Vision
{
    public class OCRCandidate
    {
        public string Text { get; set; }
        public double Confidence { get; set; }
    }
}
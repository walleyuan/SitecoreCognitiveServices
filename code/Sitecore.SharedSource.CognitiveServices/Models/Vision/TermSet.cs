using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.SharedSource.CognitiveServices.Models.Vision
{
    public class TermSet
    {
        public int Index { get; set; }
        public int OriginalIndex { get; set; }
        public int ListId { get; set; }
        public string Term { get; set; }
    }
}
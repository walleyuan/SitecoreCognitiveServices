using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.SharedSource.CognitiveServices.Models.Vision
{
    public class PersonalIdentifiableInformationSet
    {
        public string Detected { get; set; }
        public string SubType { get; set; }
        public string Text { get; set; }
        public int Index { get; set; }
    }
}
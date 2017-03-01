using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.SharedSource.CognitiveServices.Models.Knowledge.Recommendations
{
    public class FeatureWhiteList
    {
        public string Name { get; set; }
        public List<string> Values { get; set; }
    }
}
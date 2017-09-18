using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MicrosoftCognitiveServices.Foundation.MSSDK.Models.Knowledge.Recommendations
{
    public class FeatureWhiteList
    {
        public string Name { get; set; }
        public List<string> Values { get; set; }
    }
}
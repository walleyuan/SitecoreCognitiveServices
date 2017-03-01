using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.SharedSource.CognitiveServices.Models.Knowledge.Recommendations
{
    public class PerSeedBlockList
    {
        public List<string> SeedItems { get; set; }
        public List<string> ItemsToExclude { get; set; }
    }
}
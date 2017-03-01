using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.SharedSource.CognitiveServices.Models.Knowledge.Recommendations
{
    public class Upsale
    {
        public List<string> ItemIds { get; set; }
        public int NumberOfItemsToUpsale { get; set; }
    }
}
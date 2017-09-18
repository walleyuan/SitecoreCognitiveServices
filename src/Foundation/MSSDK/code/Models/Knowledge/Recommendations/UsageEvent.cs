using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Models.Knowledge.Recommendations
{
    public class UsageEvent
    {
        public string EventType { get; set; }
        public string ItemId { get; set; }
        public string Timestamp { get; set; }
        public int Count { get; set; }
        public int UnitPrice { get; set; }
    }
}
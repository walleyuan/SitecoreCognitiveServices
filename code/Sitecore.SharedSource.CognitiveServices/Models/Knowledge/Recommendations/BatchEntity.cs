using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.SharedSource.CognitiveServices.Models.Knowledge.Recommendations
{
    public class BatchEntity
    {
        public string AuthenticationType { get; set; }
        public string BaseLocation { get; set; }
        public string RelativeLocation { get; set; }
        public string SasBlobToken { get; set; }
    }
}
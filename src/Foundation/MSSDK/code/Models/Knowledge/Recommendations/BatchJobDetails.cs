using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Models.Knowledge.Recommendations
{
    public class BatchJobDetails
    {
        public string Id { get; set; }
        public BatchJobRequest RequestInfo { get; set; }
        public string Status { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Models.Knowledge.Recommendations
{
    public class BatchJob
    {
        public string ApiName { get; set; }
        public string ModelId { get; set; }
        public int BuildId { get; set; }
        public int NumberOfResults { get; set; }
        public bool IncludeMetadata { get; set; }
        public float MinimalScore { get; set; }
    }
}
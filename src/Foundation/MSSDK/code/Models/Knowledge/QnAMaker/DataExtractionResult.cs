using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Models.Knowledge.QnAMaker {
    public class DataExtractionResult {
        public string SourceType { get; set; }
        public string ExtractionStatusCode { get; set; }
        public string Source { get; set; }
    }
}

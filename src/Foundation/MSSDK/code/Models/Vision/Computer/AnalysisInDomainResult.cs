using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftCognitiveServices.Foundation.MSSDK.Models.Vision.Computer {
    public class AnalysisInDomainResult {
        public Guid RequestId { get; set; }

        public Metadata Metadata { get; set; }

        public object Result { get; set; }
    }
}

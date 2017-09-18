using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Models.Vision.Computer {
    
    public class IdentifyRequest {
        public string PersonGroupId { get; set; }
        public Guid[] FaceIds { get; set; }
        public int MaxNumOfCandidatesReturned { get; set; }
        public float ConfidenceThreshold { get; set; }
    }
}

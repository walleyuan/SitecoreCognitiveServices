using Microsoft.SharedSource.CognitiveServices.Enums;
using System;

namespace Microsoft.SharedSource.CognitiveServices.Models.Vision.Computer {
    
    public class FaceSimilarityRequest {
        public Guid FaceId { get; set; }
        public Guid[] FaceIds { get; set; }
        public string FaceListId { get; set; }
        public int MaxNumOfCandidatesReturned { get; set; }
        public FindSimilarMatchMode Mode { get; set; }
    }
}

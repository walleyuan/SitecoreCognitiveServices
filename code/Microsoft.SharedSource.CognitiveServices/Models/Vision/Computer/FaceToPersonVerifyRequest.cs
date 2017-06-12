
using System;

namespace Microsoft.SharedSource.CognitiveServices.Models.Vision.Computer {

    public class FaceToPersonVerifyRequest {
        public Guid FaceId { get; set; }
        public Guid PersonId { get; set; }
        public string PersonGroupId { get; set; }
    }
}

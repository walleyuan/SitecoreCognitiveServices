
using System;

namespace MicrosoftCognitiveServices.Foundation.MSSDK.Models.Vision.Computer {

    public class FaceToPersonVerifyRequest {
        public Guid FaceId { get; set; }
        public Guid PersonId { get; set; }
        public string PersonGroupId { get; set; }
    }
}

using MicrosoftCognitiveServices.Foundation.MSSDK.Enums;
using System;

namespace MicrosoftCognitiveServices.Foundation.MSSDK.Models.Common {
    public abstract class VideoOperationResult {
        public VideoOperationStatus Status { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public DateTime LastActionDateTime { get; set; }

        public string Message { get; set; }

        public string ResourceLocation { get; set; }

        public string ProcessingResult { get; set; }

        public VideoOperationResult() {
        }

        protected VideoOperationResult(VideoOperationResult other) {
            this.Status = other.Status;
            this.CreatedDateTime = other.CreatedDateTime;
            this.LastActionDateTime = other.LastActionDateTime;
            this.Message = other.Message;
            this.ResourceLocation = other.ResourceLocation;
            this.ProcessingResult = other.ProcessingResult;
        }
    }
}

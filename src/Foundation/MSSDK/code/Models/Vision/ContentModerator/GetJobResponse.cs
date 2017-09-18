using System.Collections.Generic;
using MicrosoftCognitiveServices.Foundation.MSSDK.Enums;

namespace MicrosoftCognitiveServices.Foundation.MSSDK.Models.Vision.ContentModerator
{
    public class GetJobResponse
    {
        public string Id { get; set; }
        public string TeamName { get; set; }
        public ContentModeratorReviewStatus Status { get; set; }
        public string WorkflowId { get; set; }
        public string CallBackEndPoint { get; set; }
        public string ReviewId { get; set; }
        public List<KeyValue> ResultMetaData { get; set; }
    }
}
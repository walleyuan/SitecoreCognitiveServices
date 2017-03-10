using System.Collections.Generic;
using Sitecore.SharedSource.CognitiveServices.Enums;

namespace Sitecore.SharedSource.CognitiveServices.Models.Vision.ContentModerator
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
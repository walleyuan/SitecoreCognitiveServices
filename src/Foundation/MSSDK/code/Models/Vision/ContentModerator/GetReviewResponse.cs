using System.Collections.Generic;
using SitecoreCognitiveServices.Foundation.MSSDK.Enums;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Models.Vision.ContentModerator
{
    public class GetReviewResponse
    {
        public string ReviewId { get; set; }
        public string ContentModeratorReviewStatus { get; set; }
        public List<KeyValue> ReviewerResultTags { get; set; }
        public string CreatedBy { get; set; }
        public List<KeyValue> Metadata { get; set; }
        public ContentModeratorReviewType Type { get; set; }
    }
}
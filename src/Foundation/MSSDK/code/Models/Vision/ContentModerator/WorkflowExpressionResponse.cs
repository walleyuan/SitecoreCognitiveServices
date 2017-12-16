
using SitecoreCognitiveServices.Foundation.MSSDK.Enums;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Models.Vision.ContentModerator
{
    public class WorkflowExpressionResponse
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ContentModeratorReviewType Type { get; set; }
    }
}
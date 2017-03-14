
using Sitecore.SharedSource.CognitiveServices.Enums;

namespace Sitecore.SharedSource.CognitiveServices.Models.Vision.ContentModerator
{
    public class WorkflowExpressionResponse
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ContentModeratorReviewType Type { get; set; }
    }
}
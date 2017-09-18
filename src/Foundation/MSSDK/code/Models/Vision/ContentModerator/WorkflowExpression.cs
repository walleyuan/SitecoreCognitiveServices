
using MicrosoftCognitiveServices.Foundation.MSSDK.Enums;

namespace MicrosoftCognitiveServices.Foundation.MSSDK.Models.Vision.ContentModerator
{
    public class WorkflowExpression
    {
        public string Description { get; set; }
        public IExpression Expression { get; set; }
        public ContentModeratorReviewType Type { get; set; }
    }
}
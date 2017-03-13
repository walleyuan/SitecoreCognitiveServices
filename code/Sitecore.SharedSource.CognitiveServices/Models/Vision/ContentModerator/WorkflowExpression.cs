
namespace Sitecore.SharedSource.CognitiveServices.Models.Vision.ContentModerator
{
    public class WorkflowExpression
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Type { get; set; }
        public IExpression Expression { get; set; }
    }
}
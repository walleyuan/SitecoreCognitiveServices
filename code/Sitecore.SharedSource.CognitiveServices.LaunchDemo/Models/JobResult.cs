using Sitecore.SharedSource.CognitiveServices.Models.Vision.ContentModerator;

namespace Sitecore.SharedSource.CognitiveServices.LaunchDemo.Models
{
    public class JobResult
    {
        public string JobId { get; set; }
        public GetJobResponse Job { get; set; }
    }
}
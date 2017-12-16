using SitecoreCognitiveServices.Foundation.MSSDK.Models.Vision.ContentModerator;

namespace SitecoreCognitiveServices.Project.LaunchDemo.Models
{
    public class JobResult
    {
        public string JobId { get; set; }
        public GetJobResponse Job { get; set; }
    }
}
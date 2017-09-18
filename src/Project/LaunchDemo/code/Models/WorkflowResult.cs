using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Vision.ContentModerator;

namespace SitecoreCognitiveServices.Project.LaunchDemo.Models
{
    public class WorkflowResult
    {
        public WorkflowExpressionResponse Workflow { get; set; }
        public List<WorkflowExpressionResponse> Workflows { get; set; }
    }
}
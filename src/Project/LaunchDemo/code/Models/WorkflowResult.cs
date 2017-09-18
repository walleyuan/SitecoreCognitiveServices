using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.SharedSource.CognitiveServices.Models.Vision.ContentModerator;

namespace Sitecore.SharedSource.CognitiveServices.LaunchDemo.Models
{
    public class WorkflowResult
    {
        public WorkflowExpressionResponse Workflow { get; set; }
        public List<WorkflowExpressionResponse> Workflows { get; set; }
    }
}
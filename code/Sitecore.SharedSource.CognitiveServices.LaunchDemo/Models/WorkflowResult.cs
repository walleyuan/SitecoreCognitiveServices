using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.SharedSource.CognitiveServices.Models.Vision.ContentModerator;

namespace Sitecore.SharedSource.CognitiveServices.LaunchDemo.Models
{
    public class WorkflowResult
    {
        public WorkflowExpression Workflow { get; set; }
        public List<WorkflowExpression> Workflows { get; set; }
    }
}
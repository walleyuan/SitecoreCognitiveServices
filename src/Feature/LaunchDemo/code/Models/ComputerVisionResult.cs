using Microsoft.SharedSource.CognitiveServices.Models.Vision.Computer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.SharedSource.CognitiveServices.LaunchDemo.Models
{
    public class ComputerVisionResult
    {
        public AnalysisResult Result { get; set; }
        public string ImageUrl { get; set; }
    }
}
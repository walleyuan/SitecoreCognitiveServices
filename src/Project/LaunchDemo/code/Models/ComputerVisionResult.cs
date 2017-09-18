using MicrosoftCognitiveServices.Foundation.MSSDK.Models.Vision.Computer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Project.LaunchDemo.Models
{
    public class ComputerVisionResult
    {
        public AnalysisResult Result { get; set; }
        public string ImageUrl { get; set; }
    }
}
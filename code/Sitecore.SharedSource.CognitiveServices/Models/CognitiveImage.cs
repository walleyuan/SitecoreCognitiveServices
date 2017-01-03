using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.ProjectOxford.Vision.Contract;

namespace Sitecore.SharedSource.CognitiveServices.Models
{
    public class CognitiveImage : ICognitiveImage
    {
        public AnalysisResult Analysis { get; set; }
        public string ItemId { get; set; }
        public string Language { get; set; }
        public string Database { get; set; }
    }
}
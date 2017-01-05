using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.ProjectOxford.Vision.Contract;

namespace Sitecore.SharedSource.CognitiveServices.Models
{
    public interface ICognitiveImage
    {
        ICognitiveImageAnalysis Analysis { get; set; }
        string ItemId { get; set; }
        string Language { get; set; }
        string Database { get; set; }
    }
}
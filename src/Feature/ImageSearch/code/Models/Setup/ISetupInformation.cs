using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Feature.ImageSearch.Models.Setup
{
    public interface ISetupInformation
    {        
        string FaceApiKey { get; set; }
        string EmotionApiKey { get; set; }
        string TextAnalyticsApiKey { get; set; }
        string ComputerVisionApiKey { get; set; }
    }
}
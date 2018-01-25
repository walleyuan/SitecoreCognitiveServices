using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Feature.ImageSearch.Models.Setup
{
    public class SetupInformation : ISetupInformation
    {
        public string FaceApiKey { get; set; }
        public string EmotionApiKey { get; set; }
        public string TextAnalyticsApiKey { get; set; }
        public string ComputerVisionApiKey { get; set; }
    }
}